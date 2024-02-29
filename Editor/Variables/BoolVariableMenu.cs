using SODD.Editor.Utils;
using SODD.Variables;
using UnityEditor;

namespace SODD.Editor.Variables
{
    public static class BoolVariableMenu
    {
        [MenuItem("Tools/" + Framework.Variables.Bool, priority = Framework.MenuOrders.Bool)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<BoolVariable>();
        }
    }
}