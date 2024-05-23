using System.Linq;
using SODD.AI;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.AI
{
    [CustomEditor(typeof(StateMachine))]
    public class StateMachineEditor : UnityEditor.Editor
    {
        private SerializedProperty statesProperty;

        private void OnEnable()
        {
            statesProperty = serializedObject.FindProperty("states");
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var stateMachine = (StateMachine)target;

            if (GUILayout.Button("Add all children states")) AddChildStates(stateMachine);
        }

        private void AddChildStates(StateMachine stateMachine)
        {
            var childStates = stateMachine.GetComponentsInChildren<State>().ToList();

            serializedObject.Update();
            statesProperty.ClearArray();
            
            for (var i = 0; i < childStates.Count; i++)
            {
                statesProperty.InsertArrayElementAtIndex(i);
                statesProperty.GetArrayElementAtIndex(i).objectReferenceValue = childStates[i];
            }

            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(stateMachine);
        }
    }
}