using System.Collections.Generic;
using ReduxSample.ToDoApp;

namespace ReduxSample.ToDoApp
{
    [System.Serializable]
    public class AddItemAction
    {
        public readonly string item;

        public AddItemAction(string item)
        {
            this.item = item;
        }
    }
    [System.Serializable]
    public class RemoveItemAction
    {
        public readonly Item item;

        public RemoveItemAction(Item item)
        {
            this.item = item;
        }
    }
    [System.Serializable]
    public class RemoveItemsAction
    {
    }
    [System.Serializable]
    public class GetItemsAction
    {
    }
    [System.Serializable]
    public class LoadedItemsAction
    {
        public readonly IList<Item> items;
        public readonly int nextId;

        public LoadedItemsAction(IList<Item> items,int nextId)
        {
            this.items = items;
            this.nextId = nextId;
        }
    }
    [System.Serializable]
    public class ItemCompletedAction
    {
        public readonly Item item;

        public ItemCompletedAction(Item item)
        {
            this.item = item;
        }
    }
}