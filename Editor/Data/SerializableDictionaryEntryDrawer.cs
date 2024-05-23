using SODD.Data;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Data
{
    [CustomPropertyDrawer(typeof(SerializableDictionary<,>.Entry))]
    public class SerializableDictionaryEntryDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var keyProperty = property.FindPropertyRelative("key");
            var valueProperty = property.FindPropertyRelative("value");
            var halfWidth = position.width / 2;
            var keyRect = new Rect(position.x, position.y + 2, halfWidth - 3, position.height - 6);
            var valueRect = new Rect(position.x + halfWidth + 2, position.y + 2, halfWidth - 3, position.height - 6);

            EditorGUI.PropertyField(keyRect, keyProperty, GUIContent.none);
            EditorGUI.PropertyField(valueRect, valueProperty, GUIContent.none);

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property.FindPropertyRelative("key")) + 4;
        }
    }
}