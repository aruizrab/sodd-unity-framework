using SODD.Editor.Utils;
using SODD.Variables;
using UnityEditor;

namespace SODD.Editor.Variables
{
    public static class Vector3VariableMenu
    {
        [MenuItem("Tools/" + Framework.Variables.Vector3, priority = Framework.MenuOrders.Vector3)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<Vector3Variable>();
        }
    }
}