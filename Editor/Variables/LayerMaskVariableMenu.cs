using SODD.Editor.Utils;
using SODD.Variables;
using UnityEditor;

namespace SODD.Editor.Variables
{
    public static class LayerMaskVariableMenu
    {
        [MenuItem("Tools/" + Framework.Variables.LayerMask, priority = Framework.MenuOrders.LayerMask)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<StringVariable>();
        }
    }
}