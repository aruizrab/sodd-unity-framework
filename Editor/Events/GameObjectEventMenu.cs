using SODD.Editor.Utils;
using SODD.Events;
using UnityEditor;

namespace SODD.Editor.Events
{
    public static class GameObjectEventMenu
    {
        [MenuItem("Tools/" + Framework.Events.GameObject, priority = Framework.MenuOrders.GameObject)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<GameObjectEvent>();
        }
    }
}