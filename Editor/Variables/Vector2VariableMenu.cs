using SODD.Editor.Utils;
using SODD.Variables;
using UnityEditor;

namespace SODD.Editor.Variables
{
    public static class Vector2VariableMenu
    {
        [MenuItem("Tools/" + Framework.Variables.Vector2, priority = Framework.MenuOrders.Vector2)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<Vector2Variable>();
        }
    }
}