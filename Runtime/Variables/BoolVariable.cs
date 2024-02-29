using UnityEngine;

namespace SODD.Variables
{
    /// <summary>
    ///     A ScriptableObject representing a boolean variable.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The BoolVariable class is a specialized implementation of the Variable class for boolean (true/false) values.
    ///         It facilitates the creation and management of a boolean value that can be shared across different components
    ///         and scripts within a Unity project, allowing for a centralized approach to handling binary states.
    ///     </para>
    ///     <para>
    ///         This class can be used to create boolean variables directly in the Unity Editor. These variables are
    ///         ideal for toggling states, managing conditions, or controlling binary features such as switches or flags
    ///         in game mechanics.
    ///     </para>
    ///     <para>
    ///         The boolean value can be marked as read-only to prevent runtime modifications. Additionally, the class
    ///         emits an event whenever the value changes, providing the capability to react dynamically to state changes.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Variables.Bool, fileName = nameof(BoolVariable),
        order = Framework.MenuOrders.Bool)]
    public class BoolVariable : Variable<bool>
    {
    }
}