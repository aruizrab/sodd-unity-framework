using SODD.Editor.Utils;
using SODD.Observers;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Observers
{
    public static class DateTimeVariableObserverMenu
    {
        [MenuItem("GameObject/" + Framework.VariableObservers.DateTime, priority = Framework.MenuOrders.DateTime)]
        [MenuItem("Tools/" + Framework.VariableObservers.DateTime, priority = Framework.MenuOrders.DateTime)]
        public static void CreateDateTimeListener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<DateTimeVariableObserver>(command.context as GameObject);
        }
    }
}