using SODD.Editor.Utils;
using SODD.Input.ActionHandlers;
using UnityEditor;

namespace SODD.Editor.Input.ActionHandlers
{
    public static class VoidInputActionHandlerMenu
    {
        [MenuItem("Tools/" + Framework.Input.ActionHandlers.Void, priority = Framework.MenuOrders.Void)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<VoidInputActionHandler>();
        }
    }
}