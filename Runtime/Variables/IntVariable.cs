using UnityEngine;

namespace SODD.Variables
{
    /// <summary>
    ///     A ScriptableObject representing an integer variable.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The IntVariable class is a specialized implementation of the Variable class for integer values.
    ///         It is designed to hold an integer value that can be shared across different components and scripts
    ///         in a Unity project, allowing for centralized management of integer data.
    ///     </para>
    ///     <para>
    ///         This class can be used to create integer variables directly in the Unity Editor. These variables
    ///         can be used for various purposes such as keeping track of scores, counts, or other numerical
    ///         game-related data that require integer representation.
    ///     </para>
    ///     <para>
    ///         The integer value can be set as read-only to prevent changes at runtime, ensuring data integrity.
    ///         The class also emits an event whenever the value changes, allowing other scripts to react to these changes.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Variables.Int, fileName = nameof(IntVariable),
        order = Framework.MenuOrders.Int)]
    public class IntVariable : Variable<int>
    {
    }
}