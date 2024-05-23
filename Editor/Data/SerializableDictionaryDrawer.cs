using SODD.Data;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Data
{
    [CustomPropertyDrawer(typeof(SerializableDictionary<,>))]
    public class SerializableDictionaryDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            var entriesProperty = property.FindPropertyRelative("entries");
            var entriesPosition = new Rect(position.x-3, position.y, position.width, position.height);
            
            EditorGUI.PropertyField(entriesPosition, entriesProperty, label, true);
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var entriesProperty = property.FindPropertyRelative("entries");
            return EditorGUI.GetPropertyHeight(entriesProperty);
        }
    }
}