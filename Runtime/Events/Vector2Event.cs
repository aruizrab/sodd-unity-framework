using UnityEngine;

namespace SODD.Events
{
    /// <summary>
    ///     Represents an event that carries a Vector2 payload.
    /// </summary>
    /// <seealso cref="Event{T}" />
    [CreateAssetMenu(menuName = Framework.Events.Vector2, fileName = nameof(Vector2Event),
        order = Framework.MenuOrders.Vector2)]
    public sealed class Vector2Event : Event<Vector2>
    {
    }
}