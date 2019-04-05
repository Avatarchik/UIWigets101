using System;
using System.Collections.Generic;
using Redux;
using UIWidgetsSample;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.gestures;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using Color = Unity.UIWidgets.ui.Color;
using TextStyle = Unity.UIWidgets.painting.TextStyle;

namespace ReduxSample.CountApp
{
    public class CounterAppSample : UIWidgetsRoutePanel
    {
        protected override Widget createWidget()
        {
            return new WidgetsApp(
                home: new CounterApp(),
                pageRouteBuilder: this.pageRouteBuilder);
        }
    }

    [Serializable]
    public class CounterState
    {
        public int count;

        public CounterState(int count = 0)
        {
            this.count = count;
        }
    }

    [Serializable]
    public class CounterIncAction
    {
        public int amount;
    }


    public class CounterApp : StatelessWidget
    {
        public override Widget build(BuildContext context)
        {
            var store = new Store<CounterState>(Reducer, new CounterState(),
                ReduxLogging.Create<CounterState>());
            return new StoreProvider<CounterState>(store, this.createWidget());
        }

        private Widget createWidget()
        {
            return new Container(
                padding: EdgeInsets.all(15),
                decoration: new BoxDecoration(
                    color: new Color(0xFF7F7F7F),
                    border: Border.all(color: Color.fromARGB(255, 255, 0, 0), width: 5),
                    borderRadius: BorderRadius.all(2)),
                child: new Column(
                    mainAxisAlignment: MainAxisAlignment.spaceAround,
                    children: new List<Widget>()
                    {
                        new StoreConnector<CounterState, string>(
                            converter: (state, dispatch) => $"Count:{state.count}",
                            builder: (context, countText) =>
                                new Center(
                                    child: new Text(countText, style: new TextStyle(
                                        fontSize: 20, fontWeight: FontWeight.w700
                                    )))
                        ),
                        new StoreConnector<CounterState, Action>(
                            converter: (state, dispatch) => () => { dispatch(new CounterIncAction() {amount = 1}); },
                            builder: (context, onPress) => new CustomButton(
                                backgroundColor: Color.fromARGB(255, 0, 204, 204),
                                padding: EdgeInsets.all(10),
                                child: new Text("Add", style: new TextStyle(
                                    fontSize: 16, color: Color.fromARGB(255, 255, 255, 255)
                                )), onPressed: () => { onPress(); })
                        ),
                    }
                )
            );
        }

        private CounterState Reducer(CounterState state, object action)
        {
            var inc = action as CounterIncAction;
            if (inc == null)
            {
                return state;
            }

            return new CounterState(inc.amount + state.count);
        }
    }

    public class CustomButton : StatelessWidget
    {
        public CustomButton(Key key = null, GestureTapCallback onPressed = null, EdgeInsets padding = null,
            Widget child = null, Color backgroundColor = null) : base(key)
        {
            this.onPressed = onPressed;
            this.padding = padding ?? EdgeInsets.all(10f);
            this.child = child;
            this.backgroundColor = backgroundColor;
        }

        public readonly GestureTapCallback onPressed;
        public readonly EdgeInsets padding;
        public readonly Widget child;
        public readonly Color backgroundColor;

        public override Widget build(BuildContext context)
        {
            return new GestureDetector(
                onTap: this.onPressed,
                child: new Container(
                    padding: this.padding,
                    decoration: new BoxDecoration(
                        color: this.backgroundColor),
                    child: this.child)
            );
        }
    }
}