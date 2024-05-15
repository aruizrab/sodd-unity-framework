using SODD.Attributes;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(CollapsibleAttribute))]
    public class CollapsiblePropertyDrawer : PropertyDrawer
    {
        private bool _foldout;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var collapsibleAttribute = attribute as CollapsibleAttribute;
            var foldoutLabel = string.IsNullOrEmpty(collapsibleAttribute?.Label)
                ? label.text
                : collapsibleAttribute.Label;

            // Create a foldout to toggle visibility
            _foldout = EditorGUI.Foldout(
                new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), _foldout,
                foldoutLabel, true);

            if (!_foldout) return;

            EditorGUI.indentLevel++;
            EditorGUI.PropertyField(
                new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 2, position.width,
                    position.height),
                property, new GUIContent(property.displayName), true
            );
            EditorGUI.indentLevel--;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return _foldout
                ? EditorGUI.GetPropertyHeight(property, label, true) + EditorGUIUtility.singleLineHeight + 5
                : EditorGUIUtility.singleLineHeight;
        }
    }
}