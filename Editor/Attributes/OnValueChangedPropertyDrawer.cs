using System.Linq;
using System.Reflection;
using SODD.Attributes;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(OnValueChangedAttribute))]
    public class OnValueChangedPropertyDrawer : PropertyDrawer
    {
        private const BindingFlags BindingFlags =
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(position, property, label);

            if (!EditorGUI.EndChangeCheck()) return;

            var onValueChangedAttribute = attribute as OnValueChangedAttribute;
            var targetObject = property.serializedObject.targetObject;
            var methodInfo = targetObject
                .GetType()
                .GetMethods(BindingFlags)
                .FirstOrDefault(info => info.Name == onValueChangedAttribute?.MethodName);

            property.serializedObject.ApplyModifiedProperties();

            if (methodInfo != null && !methodInfo.GetParameters().Any()) methodInfo.Invoke(targetObject, null);
        }
    }
}