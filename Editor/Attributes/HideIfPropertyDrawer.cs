using System;
using SODD.Attributes;
using SODD.Core;
using SODD.Editor.Utils;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(HideIfAttribute))]
    public class HideIfPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (HideProperty(property)) return;
            EditorGUI.PropertyField(position, property, label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return HideProperty(property) ? 0f : base.GetPropertyHeight(property, label);
        }

        private bool HideProperty(SerializedProperty property)
        {
            try
            {
                var hideIfAttribute = (HideIfAttribute)attribute;
                var value = EditorHelper.GetValue(property, hideIfAttribute.Name);
                return hideIfAttribute.Comparison.Evaluate(hideIfAttribute.Value, value);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }
    }
}