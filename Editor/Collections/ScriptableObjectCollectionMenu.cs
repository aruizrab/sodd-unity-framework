using SODD.Collections;
using SODD.Editor.Utils;
using UnityEditor;

namespace SODD.Editor.Collections
{
    public static class ScriptableObjectCollectionMenu
    {
        [MenuItem("Tools/" + Framework.Collections.ScriptableObject, priority = Framework.MenuOrders.ScriptableObject)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<ScriptableObjectCollection>();
        }
    }
}