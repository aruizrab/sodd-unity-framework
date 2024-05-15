using System;
using System.Linq;
using SODD.Attributes;
using SODD.Editor.Utils;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(DisableIfMatchAttribute))]
    public class DisableIfMatchPropertyDrawer : PropertyDrawer
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
                var disableIfMatchAttribute = (DisableIfMatchAttribute) attribute;
                var value = EditorHelper.GetValue(property, disableIfMatchAttribute.Name);
                return disableIfMatchAttribute.Values.Aggregate(false, (current, val) => current || Equals(value, val));
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }
    }
}