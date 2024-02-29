using SODD.Collections;
using SODD.Editor.Utils;
using UnityEditor;

namespace SODD.Editor.Collections
{
    public static class ComponentCollectionMenu
    {
        [MenuItem("Tools/" + Framework.Collections.Component, priority = Framework.MenuOrders.Component)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<ComponentCollection>();
        }
    }
}