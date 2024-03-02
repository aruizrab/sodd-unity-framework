using SODD.Editor.Utils;
using SODD.Variables;
using UnityEditor;

namespace SODD.Editor.Variables
{
    public static class FloatVariableMenu
    {
        [MenuItem("Tools/" + Framework.Variables.Float, priority = Framework.MenuOrders.Float)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<FloatVariable>();
        }
    }
}