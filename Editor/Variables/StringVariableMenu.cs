using SODD.Editor.Utils;
using SODD.Variables;
using UnityEditor;

namespace SODD.Editor.Variables
{
    public static class StringVariableMenu
    {
        [MenuItem("Tools/" + Framework.Variables.String, priority = Framework.MenuOrders.String)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<StringVariable>();
        }
    }
}