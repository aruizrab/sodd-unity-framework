using System;
using System.Linq;
using SODD.Attributes;
using SODD.Editor.Utils;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(HideIfMatchAttribute))]
    public class HideIfMatchPropertyDrawer : PropertyDrawer
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
                var hideIfMatchAttribute = (HideIfMatchAttribute) attribute;
                var value = EditorHelper.GetValue(property, hideIfMatchAttribute.Name);
                return hideIfMatchAttribute.Values.Aggregate(false, (current, val) => current || Equals(value, val));
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }
    }
}