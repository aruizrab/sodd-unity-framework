using UnityEngine;

namespace SODD.Variables
{
    /// <summary>
    ///     A ScriptableObject representing a Vector3 variable.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The Vector3Variable class is a specialized implementation of the Variable class for Vector3 values.
    ///         It is designed to hold a three-dimensional vector that can be shared across different components
    ///         and scripts in a Unity project, allowing for centralized management of Vector3 data.
    ///     </para>
    ///     <para>
    ///         This class can be used to create Vector3 variables directly in the Unity Editor. These variables
    ///         can be utilized for various purposes, such as tracking positions, velocities, directions, or other 3D
    ///         vector-related
    ///         data within your game or application.
    ///     </para>
    ///     <para>
    ///         The Vector3 value can be set as read-only to prevent changes at runtime, ensuring the integrity
    ///         of the data. The class also emits an event whenever the value changes, enabling other scripts to react
    ///         dynamically to Vector3 data updates.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Variables.Vector3, fileName = nameof(Vector3Variable),
        order = Framework.MenuOrders.Vector3)]
    public class Vector3Variable : Variable<Vector3>
    {
    }
}