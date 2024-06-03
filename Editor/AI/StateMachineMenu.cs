using SODD.AI;
using SODD.Core;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.AI
{
    public static class StateMachineMenu
    {
        [MenuItem("GameObject/" + Framework.StateMachine, priority = Framework.MenuOrders.StateMachine)]
        [MenuItem("Tools/" + Framework.StateMachine, priority = Framework.MenuOrders.StateMachine)]
        public static void CreateBoolListener(MenuCommand command)
        {
            var obj = new GameObject(ObjectNames.NicifyVariableName(nameof(StateMachine)));
            var component = obj.AddComponent<StateMachine>();
            
            obj.AddComponent<LifecycleEvents>();
            GameObjectUtility.SetParentAndAlign(obj, command.context as GameObject);
            
            var icon = EditorGUIUtility.GetIconForObject(component);
            
            EditorGUIUtility.SetIconForObject(obj, icon);
            Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
            Selection.activeObject = obj;
            EditorApplication.delayCall += () =>
            {
                EditorApplication.ExecuteMenuItem("Window/General/Hierarchy");
                Selection.activeObject = obj;
                var hierarchyWindow = EditorWindow.focusedWindow;
                if (hierarchyWindow == null) return;
                if (Selection.activeObject != obj) return;
                var renameEvent = new Event
                {
                    type = EventType.ExecuteCommand,
                    commandName = "Rename"
                };
                hierarchyWindow.SendEvent(renameEvent);
            };
        }
    }
}