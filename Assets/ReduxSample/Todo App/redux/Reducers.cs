using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ReduxSample.ToDoApp
{
    public static class Reducers
    {
        private static List<Item> cacheItems = new List<Item>(10);

        public static AppState AppStateReducer(AppState state, object action)
        {
            return new AppState(ItemsStateReducer(state.items, action), ItemIDStateReducer(state.nextId, action));
        }

        static int ItemIDStateReducer(int state, object action)
        {
            if (action is AddItemAction)
            {
                AddItemAction addAction = (AddItemAction) action;
                state++;
                cacheItems.Add(new Item(state, addAction.item, false));
            }

            if (action is LoadedItemsAction)
            {
                LoadedItemsAction _action = (LoadedItemsAction) action;
                state = _action.nextId;
            }

            return state;
        }

        static IList<Item> ItemsStateReducer(IList<Item> state, object action)
        {
            if (action is RemoveItemAction)
            {
                RemoveItemAction _action = (RemoveItemAction) action;
                cacheItems.Remove(_action.item);
                return new ReadOnlyCollection<Item>(cacheItems);
            }

            if (action is RemoveItemsAction)
            {
                cacheItems.Clear();
                return new ReadOnlyCollection<Item>(cacheItems);
            }

            if (action is LoadedItemsAction)
            {
                cacheItems.Clear();
                LoadedItemsAction _action = (LoadedItemsAction) action;
                cacheItems.AddRange(_action.items);
                return new ReadOnlyCollection<Item>(cacheItems);
            }

            if (action is ItemCompletedAction)
            {
                ItemCompletedAction _action = (ItemCompletedAction) action;
                for (var i = 0; i < cacheItems.Count; i++)
                {
                    if (cacheItems[i].id == _action.item.id)
                    {
                        Item item = cacheItems[i];
                        cacheItems[i] = new Item(item.id, item.body, !item.completed);
                        break;
                    }
                }

                return new ReadOnlyCollection<Item>(cacheItems);
            }

            return state;
        }
    }
}