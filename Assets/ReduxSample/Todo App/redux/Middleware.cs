using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Redux;

namespace ReduxSample.ToDoApp
{
    public static class Middleware
    {
        public static List<Middleware<AppState>> appStateMiddleware()
        {
            return new List<Middleware<AppState>>()
            {
                _saveToPrefs(),
                _loadFromPrefs(),
                ReduxLogging.Create<AppState>()
            };
        }

        private static Middleware<AppState> _saveToPrefs()
        {
            return (store) => (next) => (action) =>
            {
                var result = next(action);
                if (action is AddItemAction
                    || action is RemoveItemAction
                    || action is RemoveItemsAction)
                    saveToPrefs(store.state);
                return result;
            };
        }

        private static Middleware<AppState> _loadFromPrefs()
        {
            return (store) => (next) => (action) =>
            {
                var result = next(action);
                if (action is GetItemsAction)
                {
                    var state = loadFromPrefs();
                    store.Dispatch(new LoadedItemsAction(state.items,state.nextId));
                }

                return result;
            };
        }

        private static void saveToPrefs(AppState state)
        {
            string saveData = AppState.ToJson(state);
            Debug.Log("savedata: "+saveData);
            PlayerPrefs.SetString("itemsState",saveData);
            PlayerPrefs.Save();
        }

        private static AppState loadFromPrefs()
        {
            string data = PlayerPrefs.GetString("itemsState", "");
            Debug.Log("loadFromPrefs: "+data);
            if (string.IsNullOrEmpty(data))
            {
                return AppState.InitialState();
            }
            else
            {
                return AppState.FromJson(data);
            }
        }
    }
}