using SODD.Editor.Utils;
using SODD.Observers;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Observers
{
    public static class Vector2VariableObserverMenu
    {
        [MenuItem("GameObject/" + Framework.VariableObservers.Vector2, priority = Framework.MenuOrders.Vector2)]
        [MenuItem("Tools/" + Framework.VariableObservers.Vector2, priority = Framework.MenuOrders.Vector2)]
        public static void CreateVector2Listener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<Vector2VariableObserver>(command.context as GameObject);
        }
    }
}