using SODD.Editor.Utils;
using SODD.Events;
using UnityEditor;

namespace SODD.Editor.Events
{
    public static class VoidEventMenu
    {
        [MenuItem("Tools/" + Framework.Events.Void, priority = Framework.MenuOrders.Void)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<VoidEvent>();
        }
    }
}