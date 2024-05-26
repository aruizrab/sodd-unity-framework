using SODD.Editor.Utils;
using SODD.Input;
using UnityEditor;

namespace SODD.Editor.Input
{
    public static class InputActionIconProviderMenu
    {
        [MenuItem("Tools/" + Framework.Input.IconProvider)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<InputActionIconProvider>();
        }
    }
}