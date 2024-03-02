using UnityEngine;

namespace SODD.Events
{
    /// <summary>
    ///     Represents an event that carries a float payload.
    /// </summary>
    /// <seealso cref="Event{T}" />
    [CreateAssetMenu(menuName = Framework.Events.Float, fileName = nameof(FloatEvent),
        order = Framework.MenuOrders.Float)]
    public sealed class FloatEvent : Event<float>
    {
    }
}