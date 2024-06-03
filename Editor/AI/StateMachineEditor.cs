using System.Linq;
using SODD.AI;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.AI
{
    [CustomEditor(typeof(StateMachine))]
    public class StateMachineEditor : UnityEditor.Editor
    {
        private SerializedProperty _statesProperty;
        private StateMachine _stateMachine;

        private void OnEnable()
        {
            _statesProperty = serializedObject.FindProperty("states");
            _stateMachine = (StateMachine) target;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Add all children states")) AddChildStates();
        }

        private void AddChildStates()
        {
            var childStates = _stateMachine.GetComponentsInChildren<State>().ToList();

            serializedObject.Update();
            _statesProperty.ClearArray();
            
            for (var i = 0; i < childStates.Count; i++)
            {
                _statesProperty.InsertArrayElementAtIndex(i);
                _statesProperty.GetArrayElementAtIndex(i).objectReferenceValue = childStates[i];
            }

            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(_stateMachine);
        }
    }
}