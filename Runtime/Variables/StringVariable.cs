using UnityEngine;

namespace SODD.Variables
{
    /// <summary>
    ///     A ScriptableObject representing a string variable.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The StringVariable class is a specialized implementation of the Variable class for string values.
    ///         It is designed to hold a string value that can be shared across different components
    ///         and scripts in a Unity project, allowing for centralized management of string data.
    ///     </para>
    ///     <para>
    ///         This class can be used to create string variables directly in the Unity Editor. These variables
    ///         can be utilized for a range of purposes such as storing text for UI elements, dialogue,
    ///         descriptions, or any other textual content that may need to be dynamically changed or referenced
    ///         during gameplay.
    ///     </para>
    ///     <para>
    ///         The string value can be set as read-only to prevent changes at runtime, ensuring the integrity
    ///         of the textual content. The class also emits an event whenever the value changes, enabling other
    ///         scripts to react dynamically to text updates.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Variables.String, fileName = nameof(StringVariable),
        order = Framework.MenuOrders.String)]
    public class StringVariable : Variable<string>
    {
    }
}