using SODD.Editor.Utils;
using SODD.Variables;
using UnityEditor;

namespace SODD.Editor.Variables
{
    public static class DateTimeVariableMenu
    {
        [MenuItem("Tools/" + Framework.Variables.DateTime, priority = Framework.MenuOrders.DateTime)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<DateTimeVariable>();
        }
    }
}