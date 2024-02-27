using SODD.Editor.Utils;
using SODD.Listeners;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Listeners
{
    public static class BoolEventListenerMenu
    {
        [MenuItem("GameObject/" + Framework.EventListeners.Bool, priority = Framework.MenuOrders.Bool)]
        [MenuItem("Tools/" + Framework.EventListeners.Bool, priority = Framework.MenuOrders.Bool)]
        public static void CreateBoolListener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<BoolEventListener>(command.context as GameObject);
        }
    }
}