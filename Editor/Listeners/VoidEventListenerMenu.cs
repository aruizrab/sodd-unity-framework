using SODD.Editor.Utils;
using SODD.Listeners;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Listeners
{
    public static class VoidEventListenerMenu
    {
        [MenuItem("GameObject/" + Framework.EventListeners.Void, priority = Framework.MenuOrders.Void)]
        [MenuItem("Tools/" + Framework.EventListeners.Void, priority = Framework.MenuOrders.Void)]
        public static void CreateVoidListener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<VoidEventListener>(command.context as GameObject);
        }
    }
}