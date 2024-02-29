using SODD.Collections;
using SODD.Editor.Utils;
using UnityEditor;

namespace SODD.Editor.Collections
{
    public static class GameObjectCollectionMenu
    {
        [MenuItem("Tools/" + Framework.Collections.GameObject, priority = Framework.MenuOrders.GameObject)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<GameObjectCollection>();
        }
    }
}