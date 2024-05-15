using System;
using System.Linq;
using SODD.Attributes;
using SODD.Editor.Utils;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(ShowIfMatchAttribute))]
    public class ShowIfMatchPropertyDrawer : PropertyDrawer
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
                var showIfMatchAttribute = (ShowIfMatchAttribute)attribute;
                var value = EditorHelper.GetValue(property, showIfMatchAttribute.Name);
                return showIfMatchAttribute.Values.Aggregate(false, (current, val) => current || Equals(value, val));
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return true;
            }
        }
    }
}