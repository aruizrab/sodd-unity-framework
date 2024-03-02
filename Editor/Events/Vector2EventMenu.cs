using SODD.Editor.Utils;
using SODD.Events;
using UnityEditor;

namespace SODD.Editor.Events
{
    public static class Vector2EventMenu
    {
        [MenuItem("Tools/" + Framework.Events.Vector2, priority = Framework.MenuOrders.Vector2)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<Vector2Event>();
        }
    }
}