using SODD.Editor.Utils;
using SODD.Input;
using UnityEditor;

namespace SODD.Editor.Input
{
    public static class ControlSchemeHandlerMenu
    {
        [MenuItem("Tools/" + Framework.Input.ControlSchemeHandler)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<ControlSchemeHandler>();
        }
    }
}