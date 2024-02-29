using SODD.Editor.Utils;
using SODD.Variables;
using UnityEditor;

namespace SODD.Editor.Variables
{
    public static class IntVariableMenu
    {
        [MenuItem("Tools/" + Framework.Variables.Int, priority = Framework.MenuOrders.Int)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<IntVariable>();
        }
    }
}