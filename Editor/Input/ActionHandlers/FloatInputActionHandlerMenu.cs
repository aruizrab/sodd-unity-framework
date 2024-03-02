using SODD.Editor.Utils;
using SODD.Input.ActionHandlers;
using UnityEditor;

namespace SODD.Editor.Input.ActionHandlers
{
    public static class FloatInputActionHandlerMenu
    {
        [MenuItem("Tools/" + Framework.Input.ActionHandlers.Float, priority = Framework.MenuOrders.Float)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<FloatInputActionHandler>();
        }
    }
}