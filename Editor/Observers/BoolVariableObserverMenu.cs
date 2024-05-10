using SODD.Editor.Utils;
using SODD.Observers;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Observers
{
    public static class BoolVariableObserverMenu
    {
        [MenuItem("GameObject/" + Framework.VariableObservers.Bool, priority = Framework.MenuOrders.Bool)]
        [MenuItem("Tools/" + Framework.VariableObservers.Bool, priority = Framework.MenuOrders.Bool)]
        public static void CreateBoolListener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<BoolVariableObserver>(command.context as GameObject);
        }
    }
}