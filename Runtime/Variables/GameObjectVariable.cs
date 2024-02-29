using UnityEngine;

namespace SODD.Variables
{
    /// <summary>
    ///     A ScriptableObject representing a GameObject variable.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The GameObjectVariable class is a specialized implementation of the Variable class for GameObject values.
    ///         It is designed to hold a GameObject value that can be shared across different components
    ///         and scripts in a Unity project, allowing for centralized management of GameObject data.
    ///     </para>
    ///     <para>
    ///         This class can be used to create GameObject variables directly in the Unity Editor. These variables
    ///         can be utilized for a range of purposes such as storing references to key GameObjects, controlling
    ///         object behavior, or any other interactions that may need to be dynamically changed or referenced
    ///         during gameplay.
    ///     </para>
    ///     <para>
    ///         The GameObject value can be set as read-only to prevent changes at runtime, ensuring the consistency of 
    ///         object interactions. The class also emits an event whenever the value changes, enabling other
    ///         scripts to react dynamically to GameObject updates.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Variables.GameObject, fileName = nameof(GameObjectVariable),
        order = Framework.MenuOrders.GameObject)]
    public class GameObjectVariable : Variable<GameObject>
    {
    }
}