using SODD.Input.ActionHandlers;
using UnityEditor;

namespace SODD.Editor.Input.ActionHandlers
{
    [CustomEditor(typeof(VoidInputActionHandler))]
    public class VoidInputActionHandlerEditor: UnityEditor.Editor
    {
        private SerializedProperty _inputActionReference;
        private SerializedProperty _onActionStarted;
        private SerializedProperty _onActionPerformed;
        private SerializedProperty _onActionCanceled;

        private void OnEnable()
        {
            _inputActionReference = serializedObject.FindProperty("inputActionReference");
            _onActionStarted = serializedObject.FindProperty("onActionStarted");
            _onActionStarted = serializedObject.FindProperty("onActionStarted");
            _onActionPerformed = serializedObject.FindProperty("onActionPerformed");
            _onActionCanceled = serializedObject.FindProperty("onActionCanceled");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_inputActionReference);
            EditorGUILayout.PropertyField(_onActionStarted);
            EditorGUILayout.PropertyField(_onActionPerformed);
            EditorGUILayout.PropertyField(_onActionCanceled);

            serializedObject.ApplyModifiedProperties();
        }
    }
}