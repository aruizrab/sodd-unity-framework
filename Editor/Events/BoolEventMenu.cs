using SODD.Editor.Utils;
using SODD.Events;
using UnityEditor;

namespace SODD.Editor.Events
{
    public static class BoolEventMenu
    {
        [MenuItem("Tools/" + Framework.Events.Bool, priority = Framework.MenuOrders.Bool)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<BoolEvent>();
        }
    }
}