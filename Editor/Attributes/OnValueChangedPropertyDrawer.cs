using System.Linq;
using SODD.Attributes;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(OnValueChangedAttribute))]
    public class OnValueChangedPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(position, property, label);

            if (!EditorGUI.EndChangeCheck()) return;

            var targetObject = property.serializedObject.targetObject;
            var onValueChangedAttribute = attribute as OnValueChangedAttribute;
            var methodName = onValueChangedAttribute?.MethodName;
            var classType = targetObject.GetType();
            var methodInfo = classType.GetMethods().FirstOrDefault(info => info.Name == methodName);

            property.serializedObject.ApplyModifiedProperties();

            if (methodInfo != null && !methodInfo.GetParameters().Any()) methodInfo.Invoke(targetObject, null);
        }
    }
}