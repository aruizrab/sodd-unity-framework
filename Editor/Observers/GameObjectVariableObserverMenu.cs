using SODD.Editor.Utils;
using SODD.Observers;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Observers
{
    public static class GameObjectVariableObserverMenu
    {
        [MenuItem("GameObject/" + Framework.VariableObservers.GameObject, priority = Framework.MenuOrders.GameObject)]
        [MenuItem("Tools/" + Framework.VariableObservers.GameObject, priority = Framework.MenuOrders.GameObject)]
        public static void CreateGameObjectListener(MenuCommand command)
        {
            EditorHelper.CreateGameObject<GameObjectVariableObserver>(command.context as GameObject);
        }
    }
}