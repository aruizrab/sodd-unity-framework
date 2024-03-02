using SODD.Editor.Utils;
using SODD.Listeners;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Listeners
{
    public static class StringEventListenerMenu
    {
        [MenuItem("GameObject/" + Framework.EventListeners.String, priority = Framework.MenuOrders.String)]
        [MenuItem("Tools/" + Framework.EventListeners.String, priority = Framework.MenuOrders.String)]
        public static void CreateStringListener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<StringEventListener>(command.context as GameObject);
        }
    }
}