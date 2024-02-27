using SODD.Editor.Utils;
using SODD.Listeners;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Listeners
{
    public static class IntEventListenerMenu
    {
        [MenuItem("GameObject/" + Framework.EventListeners.Int, priority = Framework.MenuOrders.Int)]
        [MenuItem("Tools/" + Framework.EventListeners.Int, priority = Framework.MenuOrders.Int)]
        public static void CreateIntListener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<IntEventListener>(command.context as GameObject);
        }
    }
}