using SODD.Editor.Utils;
using SODD.Input.ActionHandlers;
using UnityEditor;

namespace SODD.Editor.Input.ActionHandlers
{
    public static class BoolInputActionHandlerMenu
    {
        [MenuItem("Tools/" + Framework.Input.ActionHandlers.Bool, priority = Framework.MenuOrders.Bool)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<BoolInputActionHandler>();
        }
    }
}