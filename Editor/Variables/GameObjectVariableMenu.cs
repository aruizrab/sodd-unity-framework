using SODD.Editor.Utils;
using SODD.Variables;
using UnityEditor;

namespace SODD.Editor.Variables
{
    public static class GameObjectVariableMenu
    {
        [MenuItem("Tools/" + Framework.Variables.GameObject, priority = Framework.MenuOrders.GameObject)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<GameObjectVariable>();
        }
    }
}