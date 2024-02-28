using SODD.Editor.Utils;
using SODD.Listeners;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Listeners
{
    public static class Vector2EventListenerMenu
    {
        [MenuItem("GameObject/" + Framework.EventListeners.Vector2, priority = Framework.MenuOrders.Vector2)]
        [MenuItem("Tools/" + Framework.EventListeners.Vector2, priority = Framework.MenuOrders.Vector2)]
        public static void CreateVector2Listener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<Vector2EventListener>(command.context as GameObject);
        }
    }
}