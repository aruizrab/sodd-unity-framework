using SODD.Editor.Utils;
using SODD.Events;
using UnityEditor;

namespace SODD.Editor.Events
{
    public static class IntEventMenu
    {
        [MenuItem("Tools/" + Framework.Events.Int, priority = Framework.MenuOrders.Int)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<IntEvent>();
        }
    }
}