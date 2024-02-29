using SODD.Collections;
using SODD.Editor.Utils;
using UnityEditor;

namespace SODD.Editor.Collections
{
    public static class ObjectCollectionMenu
    {
        [MenuItem("Tools/" + Framework.Collections.Object, priority = Framework.MenuOrders.Object)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<ObjectCollection>();
        }
    }
}