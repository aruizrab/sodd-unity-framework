using SODD.Editor.Utils;
using SODD.Input.ActionHandlers;
using UnityEditor;

namespace SODD.Editor.Input.ActionHandlers
{
    public static class Vector2InputActionHandlerMenu
    {
        [MenuItem("Tools/" + Framework.Input.ActionHandlers.Vector2, priority = Framework.MenuOrders.Vector2)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<Vector2InputActionHandler>();
        }
    }
}