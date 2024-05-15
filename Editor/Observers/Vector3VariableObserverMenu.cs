using SODD.Editor.Utils;
using SODD.Observers;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Observers
{
    public static class Vector3VariableObserverMenu
    {
        [MenuItem("GameObject/" + Framework.VariableObservers.Vector3, priority = Framework.MenuOrders.Vector3)]
        [MenuItem("Tools/" + Framework.VariableObservers.Vector3, priority = Framework.MenuOrders.Vector3)]
        public static void CreateVector3Listener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<Vector3VariableObserver>(command.context as GameObject);
        }
    }
}