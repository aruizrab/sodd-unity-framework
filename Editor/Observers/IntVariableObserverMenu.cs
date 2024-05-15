using SODD.Editor.Utils;
using SODD.Observers;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Observers
{
    public static class IntVariableObserverMenu
    {
        [MenuItem("GameObject/" + Framework.VariableObservers.Int, priority = Framework.MenuOrders.Int)]
        [MenuItem("Tools/" + Framework.VariableObservers.Int, priority = Framework.MenuOrders.Int)]
        public static void CreateIntListener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<IntVariableObserver>(command.context as GameObject);
        }
    }
}