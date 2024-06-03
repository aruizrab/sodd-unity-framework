using SODD.Core;
using SODD.Repositories;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Repositories
{
    [CustomEditor(typeof(VariableRepository))]
    public class VariableRepositoryCustomEditor : UnityEditor.Editor
    {
        private VariableRepository _repository;
        private SerializedProperty _variables;

        private void OnEnable()
        {
            _repository = (VariableRepository)target;
            _variables = serializedObject.FindProperty("variables");
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Add Persistent Variables")) AddPersistentVariables();
            if (GUILayout.Button("Load")) _repository.Load();
            if (GUILayout.Button("Save")) _repository.Save();
            if (GUILayout.Button("Delete")) _repository.Delete();
        }

        private void AddPersistentVariables()
        {
            _variables.ClearArray();

            AssetDatabase.FindAssets("t:PersistentScriptableObject").ForEach(guid =>
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<PersistentScriptableObject>(path);

                if (!asset || !asset.persist) return;

                _variables.InsertArrayElementAtIndex(_variables.arraySize);
                _variables.GetArrayElementAtIndex(_variables.arraySize - 1).objectReferenceValue = asset;
            });

            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(_repository);
            AssetDatabase.SaveAssets();
        }
    }
}