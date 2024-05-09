using System;
using SODD.Attributes;
using SODD.Core;
using SODD.Editor.Utils;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(DisableIfAttribute))]
    public class DisableIfPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var guiState = GUI.enabled;
            GUI.enabled = !DisableProperty(property);
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = guiState;
        }

        private bool DisableProperty(SerializedProperty property)
        {
            try
            {
                var disableIfAttribute = (DisableIfAttribute) attribute;
                var value = EditorHelper.GetValue(property, disableIfAttribute.Name);
                return disableIfAttribute.Comparison.Evaluate(disableIfAttribute.Value, value);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }
    }
}