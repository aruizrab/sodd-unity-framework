using SODD.Editor.Utils;
using SODD.Events;
using UnityEditor;

namespace SODD.Editor.Events
{
    public static class Vector3EventMenu
    {
        [MenuItem("Tools/" + Framework.Events.Vector3, priority = Framework.MenuOrders.Vector3)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<Vector3Event>();
        }
    }
}