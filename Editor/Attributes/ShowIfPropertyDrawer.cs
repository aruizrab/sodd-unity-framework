using System;
using SODD.Attributes;
using SODD.Core;
using SODD.Editor.Utils;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public class ShowIfPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!ShowProperty(property)) return;
            EditorGUI.PropertyField(position, property, label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return ShowProperty(property) ? base.GetPropertyHeight(property, label) : 0f;
        }

        private bool ShowProperty(SerializedProperty property)
        {
            try
            {
                var showIfAttribute = (ShowIfAttribute)attribute;
                var value = EditorHelper.GetValue(property, showIfAttribute.Name);
                return showIfAttribute.Comparison.Evaluate(showIfAttribute.Value, value);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return true;
            }
        }
    }
}