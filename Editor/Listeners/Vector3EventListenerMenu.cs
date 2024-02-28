using SODD.Editor.Utils;
using SODD.Listeners;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Listeners
{
    public static class Vector3EventListenerMenu
    {
        [MenuItem("GameObject/" + Framework.EventListeners.Vector3, priority = Framework.MenuOrders.Vector3)]
        [MenuItem("Tools/" + Framework.EventListeners.Vector3, priority = Framework.MenuOrders.Vector3)]
        public static void CreateVector3Listener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<Vector3EventListener>(command.context as GameObject);
        }
    }
}