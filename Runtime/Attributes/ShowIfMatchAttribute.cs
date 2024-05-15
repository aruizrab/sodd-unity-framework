using System;
using UnityEngine;

namespace SODD.Attributes
{
    /// <summary>
    ///     Shows the property or field in the Unity Inspector if the value of the specified field or property matches any of
    ///     the given values,
    ///     and hides it otherwise.
    /// </summary>
    /// <remarks>
    ///     This attribute can be used to conditionally show or hide properties or fields from the Unity Inspector based on the
    ///     state
    ///     of other properties or fields within the same object. It is particularly useful for managing complex user
    ///     interfaces,
    ///     allowing the display of relevant options only when appropriate.
    /// </remarks>
    /// <example>
    ///     The following example shows how to use the ShowIfMatchAttribute to conditionally show a property:
    ///     <code>
    /// public class GameplaySettings : MonoBehaviour
    /// {
    ///     public string difficultyLevel;
    /// 
    ///     [ShowIfMatch("difficultyLevel", "Hard", "Extreme")]
    ///     public float damageMultiplier;
    /// }
    /// </code>
    ///     In this example, the 'damageMultiplier' property will only be visible in the Inspector when 'difficultyLevel'
    ///     is set to "Hard" or "Extreme".
    /// </example>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ShowIfMatchAttribute : PropertyAttribute
    {
        public readonly string Name;
        public readonly object[] Values;

        public ShowIfMatchAttribute(string name, params object[] values)
        {
            Name = name;
            Values = values;
        }
    }
}