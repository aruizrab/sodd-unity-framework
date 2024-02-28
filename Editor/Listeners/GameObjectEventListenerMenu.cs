using SODD.Editor.Utils;
using SODD.Listeners;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Listeners
{
    public static class GameObjectEventListenerMenu
    {
        [MenuItem("GameObject/" + Framework.EventListeners.GameObject, priority = Framework.MenuOrders.GameObject)]
        [MenuItem("Tools/" + Framework.EventListeners.GameObject, priority = Framework.MenuOrders.GameObject)]
        public static void CreateGameObjectListener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<GameObjectEventListener>(command.context as GameObject);
        }
    }
}