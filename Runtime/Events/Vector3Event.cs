using UnityEngine;

namespace SODD.Events
{
    /// <summary>
    ///     A ScriptableObject that represents an event carrying an Vector3 payload.
    /// </summary>
    /// <seealso cref="Event{T}" />
    [CreateAssetMenu(menuName = Framework.Events.Vector3, fileName = nameof(Vector3Event), order = Framework.MenuOrders.Vector3)]
    public sealed class Vector3Event : Event<Vector3>
    {
    }
}