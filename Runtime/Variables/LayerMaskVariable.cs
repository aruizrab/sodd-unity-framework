using UnityEngine;

namespace SODD.Variables
{
    /// <summary>
    ///     A ScriptableObject representing a LayerMask variable.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The LayerMaskVariable class is a specialized implementation of the Variable class for LayerMask values.
    ///         It is designed to hold a LayerMask value that can be shared across different components
    ///         and scripts in a Unity project, allowing for centralized management of LayerMask data.
    ///     </para>
    ///     <para>
    ///         This class can be used to create LayerMask variables directly in the Unity Editor. These variables
    ///         can be utilized for a range of purposes such as setting certain layers to interact or not interact with
    ///         others, managing collision detection, or any other game rules that may need to be dynamically changed or 
    ///         referenced during gameplay.
    ///     </para>
    ///     <para>
    ///         The LayerMask value can be set as read-only to prevent changes at runtime, ensuring the consistency of 
    ///         layer rules. The class also emits an event whenever the value changes, enabling other
    ///         scripts to react dynamically to LayerMask updates.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Variables.LayerMask, fileName = nameof(LayerMaskVariable),
        order = Framework.MenuOrders.LayerMask)]
    public class LayerMaskVariable : Variable<LayerMask>
    {
    }
}