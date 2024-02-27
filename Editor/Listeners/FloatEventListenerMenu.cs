using SODD.Editor.Utils;
using SODD.Listeners;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Listeners
{
    public static class FloatEventListenerMenu
    {
        [MenuItem("GameObject/" + Framework.EventListeners.Float, priority = Framework.MenuOrders.Float)]
        [MenuItem("Tools/" + Framework.EventListeners.Float, priority = Framework.MenuOrders.Float)]
        public static void CreateFloatListener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<FloatEventListener>(command.context as GameObject);
        }
    }
}