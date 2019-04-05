using Unity.UIWidgets.widgets;
using UnityEngine;

namespace Redux
{
    public static class ReduxLogging
    {
        public static Middleware<State> Create<State>()
        {
            return (store) => (next) => (action) =>
            {
                var previousState = store.state;
                var previousStateDump = JsonUtility.ToJson(previousState);
                var result = next(action);
                var afterState = store.state;
                var afterStateDump = JsonUtility.ToJson(afterState);
                Debug.LogFormat("Action name={0}  data={1}  previousState:{2} afterState={3}",
                    action.GetType().Name,
                    JsonUtility.ToJson(action),
                    previousStateDump,
                    afterStateDump);
                return result;
            };
        }
    }
}