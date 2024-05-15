using SODD.Repositories;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Repositories
{
    [CustomEditor(typeof(VariableRepository))]
    public class VariableRepositoryCustomEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var repository = (VariableRepository) target;

            DrawDefaultInspector();

            if (GUILayout.Button("Load")) repository.Load();
            if (GUILayout.Button("Save")) repository.Save();
            if (GUILayout.Button("Delete")) repository.Delete();
        }
    }
}