using UnityEngine;

namespace SODD.Variables
{
    /// <summary>
    ///     A ScriptableObject representing a floating-point number variable.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The FloatVariable class is a specialized implementation of the Variable class for float values.
    ///         It is designed to hold a floating-point number that can be shared across different components
    ///         and scripts in a Unity project, allowing for centralized management of float data.
    ///     </para>
    ///     <para>
    ///         This class can be used to create float variables directly in the Unity Editor. These variables
    ///         can be utilized for a range of purposes such as tracking dynamic numerical values like health points,
    ///         speed, percentages, or any other measurements that require floating-point precision.
    ///     </para>
    ///     <para>
    ///         The float value can be set as read-only to prevent changes at runtime, maintaining data integrity.
    ///         The class also emits an event whenever the value changes, enabling other scripts to respond dynamically
    ///         to these changes.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Variables.Float, fileName = nameof(FloatVariable),
        order = Framework.MenuOrders.Float)]
    public class FloatVariable : Variable<float>
    {
    }
}