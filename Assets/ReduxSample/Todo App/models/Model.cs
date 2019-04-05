using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using UnityEngine;

namespace ReduxSample.ToDoApp
{
    [System.Serializable]
    public class Item
    {
        public int id;
        public string body;
        public bool completed;

        public Item(int id, string body, bool completed)
        {
            this.id = id;
            this.body = body;
            this.completed = completed;
        }


        public static Item FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Item>(json);
        }

        public static string ToJson(Item item)
        {
            return JsonConvert.SerializeObject(item);
        }

        public override string ToString()
        {
            return ToJson(this);
        }
    }

    [Serializable]
    public class AppState
    {
        [SerializeField] public int nextId;
        [SerializeField] 
        public IList<Item> items;

        public AppState(IList<Item> items,int nextId)
        {
            this.items = items;
            this.nextId = nextId;
        }

        public static AppState InitialState()
        {
            List<Item> empty = new List<Item>(0);
            return new AppState(new ReadOnlyCollection<Item>(empty),1);
        }

        public static AppState FromJson(string json)
        {
            return JsonConvert.DeserializeObject<AppState>(json);
        }

        public static string ToJson(AppState state)
        {
            return JsonConvert.SerializeObject(state);
        }
    }
}