using SODD.Editor.Utils;
using SODD.Input.ActionHandlers;
using UnityEditor;

namespace SODD.Editor.Input.ActionHandlers
{
    public static class Vector3InputActionHandlerMenu
    {
        [MenuItem("Tools/" + Framework.Input.ActionHandlers.Vector3, priority = Framework.MenuOrders.Vector3)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<Vector3InputActionHandler>();
        }
    }
}