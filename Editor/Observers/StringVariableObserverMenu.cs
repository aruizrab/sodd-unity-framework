using SODD.Editor.Utils;
using SODD.Observers;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Observers
{
    public static class StringVariableObserverMenu
    {
        [MenuItem("GameObject/" + Framework.VariableObservers.String, priority = Framework.MenuOrders.String)]
        [MenuItem("Tools/" + Framework.VariableObservers.String, priority = Framework.MenuOrders.String)]
        public static void CreateStringListener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<StringVariableObserver>(command.context as GameObject);
        }
    }
}