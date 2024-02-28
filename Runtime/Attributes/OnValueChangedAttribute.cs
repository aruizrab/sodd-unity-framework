using System;
using UnityEngine;

namespace SODD.Attributes
{
    /// <summary>
    ///     Calls the specified method whenever the value of the serialized field is modified in the editor.
    /// </summary>
    /// <remarks>
    ///     The specified method should exist in the same class as the field and should have no parameters.
    /// </remarks>
    /// <example>
    ///     <code>
    ///         using UnityEngine;
    ///         using SODD.Attributes;
    /// 
    ///         public class ExampleBehaviour : MonoBehaviour
    ///         {
    ///             [OnValueChanged("OnHealthChanged")]
    ///             public int health;
    /// 
    ///             private void OnHealthChanged()
    ///             {
    ///                 Debug.Log("Health value changed to: " + health);
    ///             }
    ///         }
    ///     </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class OnValueChangedAttribute : PropertyAttribute
    {
        public readonly string MethodName;

        public OnValueChangedAttribute(string methodName)
        {
            MethodName = methodName;
        }
    }
}