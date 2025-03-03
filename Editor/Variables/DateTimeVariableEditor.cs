using System;
using System.Globalization;
using SODD.Variables;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Variables
{
    [CustomEditor(typeof(DateTimeVariable))]
    public class DateTimeVariableEditor : UnityEditor.Editor
    {
        private SerializedProperty formatProp;
        private SerializedProperty formattedValueProp;
        private SerializedProperty localizationProp;

        private void OnEnable()
        {
            formatProp = serializedObject.FindProperty("format");
            localizationProp = serializedObject.FindProperty("localization");
            formattedValueProp = serializedObject.FindProperty("formattedValue");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (!GUILayout.Button("Update DateTime from Formatted Value")) return;

            var variable = (DateTimeVariable)target;
            var culture = CultureInfo.GetCultureInfo(localizationProp.stringValue);
            var newValue = DateTime.ParseExact(formattedValueProp.stringValue, formatProp.stringValue, culture);

            variable.Value = newValue;

            EditorUtility.SetDirty(variable);
        }
    }
}