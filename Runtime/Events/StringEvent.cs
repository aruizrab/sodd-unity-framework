using UnityEngine;

namespace SODD.Events
{
    /// <summary>
    ///     A ScriptableObject that represents an event carrying an string payload.
    /// </summary>
    /// <seealso cref="Event{T}" />
    [CreateAssetMenu(menuName = Framework.Events.String, fileName = nameof(StringEvent), order = Framework.MenuOrders.String)]
    public sealed class StringEvent : Event<string>
    {
    }
}