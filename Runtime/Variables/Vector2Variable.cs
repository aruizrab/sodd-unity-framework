using UnityEngine;

namespace SODD.Variables
{
    /// <summary>
    /// A ScriptableObject representing a Vector2 variable.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The Vector2Variable class is a specialized implementation of the Variable class for Vector2 values.
    /// It is designed to hold a two-dimensional vector that can be shared across different components
    /// and scripts in a Unity project, allowing for centralized management of Vector2 data.
    /// </para>
    /// <para>
    /// This class can be used to create Vector2 variables directly in the Unity Editor. These variables
    /// can be utilized for various purposes, such as tracking positions, velocities, or other 2D vector-related
    /// data within your game or application.
    /// </para>
    /// <para>
    /// The Vector2 value can be set as read-only to prevent changes at runtime, ensuring the integrity
    /// of the data. The class also emits an event whenever the value changes, enabling other scripts to react
    /// dynamically to Vector2 data updates.
    /// </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Variables.Vector2, fileName = nameof(Vector2Variable),
        order = Framework.MenuOrders.Vector2)]
    public class Vector2Variable : Variable<Vector2>
    {
    }
}