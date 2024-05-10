using SODD.Editor.Utils;
using SODD.Observers;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Observers
{
    public static class FloatVariableObserverMenu
    {
        [MenuItem("GameObject/" + Framework.VariableObservers.Float, priority = Framework.MenuOrders.Float)]
        [MenuItem("Tools/" + Framework.VariableObservers.Float, priority = Framework.MenuOrders.Float)]
        public static void CreateFloatListener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<FloatVariableObserver>(command.context as GameObject);
        }
    }
}