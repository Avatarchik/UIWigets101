using System;
using System.Collections.Generic;
using System.Linq;
using Redux;
using ReduxSample.ToDoApp;
using UIWidgetsSample;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;
using TextStyle = Unity.UIWidgets.painting.TextStyle;

namespace ReduxSample.Todo_App
{
    public class ToDoApp : UIWidgetsRoutePanel
    {
        private Store<AppState> _store;

        private Store<AppState> store
        {
            get
            {
                if (_store == null)
                {
                    _store = new Store<AppState>(
                        reducer: Reducers.AppStateReducer,
                        initialState: AppState.InitialState(),
                        middlewares: Middleware.appStateMiddleware().ToArray());
                    store.Dispatch(new GetItemsAction());
                }

                return _store;
            }
        }

        protected override void OnEnable()
        {
            FontManager.instance.addFont(Resources.Load<Font>(path: "MaterialIcons-Regular"), "Material Icons");
            base.OnEnable();
        }

        protected override Widget createWidget()
        {
            return new StoreProvider<AppState>(store,
                child: new MaterialApp(
                    title: "TODO APP",
                    theme: ThemeData.light(),
                    home: new StoreConnector<AppState, _ViewModel>(
                        converter: (state, dispatcher) => new _ViewModel(store),
                        builder: (context, viewmodel) =>
                        {
                            return new Scaffold(
                                appBar: new AppBar(
                                    title: new Text("ToDo App")),
                                body: new Container(
                                    child: new Column(
                                        children: new List<Widget>()
                                        {
                                            new AddItemWidget(viewmodel),
                                            new Expanded(child: new ItemListWidget(viewmodel)),
                                            new RemoveItemButton(viewmodel)
                                        })
                                ));
                        })
                ));
        }
    }


    class ItemListWidget : StatelessWidget
    {
        readonly _ViewModel model;

        public ItemListWidget(_ViewModel odel, Key key = null) : base(key)
        {
            model = odel;
        }

        public override Widget build(BuildContext context)
        {
            return
                new Container(
                    child: new ListView(
                        children: this.model.items.Select(
                            (item,i) =>
                            {
                                var modelItem = this.model.items[i];
                                return
                                    (Widget) new ListTile(
                                        title: new Text(modelItem.body),
                                        leading: new IconButton(
                                            icon: new Icon(Icons.delete), onPressed:
                                            () => { model.onRemoveItem(modelItem); }),
                                        trailing: new Checkbox(
                                            value: modelItem.completed,
                                            onChanged: (value) => this.model.onCompletedItem(modelItem)
                                        )
                                    );
                            }
                        ).ToList()));
        }
    }


    class RemoveItemButton : StatelessWidget
    {
        readonly _ViewModel model;

        public RemoveItemButton(_ViewModel model, Key key = null) : base(key)
        {
            this.model = model;
        }

        public override Widget build(BuildContext context)
        {
            return new RaisedButton(
                child: new Text("delete all items"),
                onPressed: () => model.onRemoveItems()
            );
        }
    }

    class AddItemWidget : StatefulWidget
    {
        public readonly _ViewModel model;

        public AddItemWidget(_ViewModel odel, Key key = null) : base(key)
        {
            model = odel;
        }

        public override State createState()
        {
            return new _AddItemState();
        }
    }

    class _AddItemState : State<AddItemWidget>
    {
        readonly TextEditingController controller = new TextEditingController("");

        private void _addItem()
        {
            if (!string.IsNullOrWhiteSpace(controller.text))
            {
                widget.model.onAddItems(controller.text);
                controller.clear();
            }
        }

        public override Widget build(BuildContext context)
        {
            return new Container(
                child: new Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: new List<Widget>
                    {
                        new Container(
                            width: 300,
                            decoration: new BoxDecoration(border: Border.all(new Color(0xFF000000), 1)),
                            padding: EdgeInsets.fromLTRB(8, 0, 8, 0),
                            child: new EditableText(maxLines: 1,
                                controller: this.controller,
                                onSubmitted: (text) => { _addItem(); },
                                selectionControls: MaterialUtils.materialTextSelectionControls,
                                autofocus: true,
                                focusNode: new FocusNode(),
                                style: new TextStyle(
                                    fontSize: 18,
                                    height: 1.5f,
                                    color: new Color(0xFF1389FD)
                                ),
                                selectionColor: Color.fromARGB(255, 255, 0, 0),
                                cursorColor: Color.fromARGB(255, 0, 0, 0))
                        ),
                        new RaisedButton(
                            color: Color.fromARGB(255, 0, 204, 204),
                            padding: EdgeInsets.all(10),
                            child: new Text("Add", style: new TextStyle(
                                fontSize: 20, color: Color.fromARGB(255, 255, 255, 255), fontWeight: FontWeight.w700
                            )), onPressed: _addItem)
                    }
                ));
        }
    }

    class _ViewModel
    {
        public readonly IList<Item> items;
        public readonly Action<string> onAddItems;
        public readonly Action<Item> onRemoveItem;
        public readonly Action<Item> onCompletedItem;
        public readonly Action onRemoveItems;


        public _ViewModel(Store<AppState> store)
        {
            this.items = store.state.items;
            this.onAddItems = (body) => { store.Dispatch(new AddItemAction(body)); };
            this.onRemoveItem = item => store.Dispatch(new RemoveItemAction(item));
            this.onCompletedItem = item => store.Dispatch(new ItemCompletedAction(item));
            this.onRemoveItems = () => store.Dispatch(new RemoveItemsAction());
        }
    }
}