using SODD.AI;
using SODD.Editor.Utils;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.AI
{
    public static class StateMenu
    {
        [MenuItem("GameObject/" + Framework.State, priority = Framework.MenuOrders.State)]
        [MenuItem("Tools/" + Framework.State, priority = Framework.MenuOrders.State)]
        public static void CreateBoolListener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<State>(command.context as GameObject, true);
        }
    }
}