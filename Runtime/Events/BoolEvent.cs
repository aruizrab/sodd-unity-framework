using UnityEngine;

namespace SODD.Events
{
    /// <summary>
    ///     A ScriptableObject that represents an event carrying an boolean payload.
    /// </summary>
    /// <seealso cref="Event{T}" />
    [CreateAssetMenu(menuName = Framework.Events.Bool, fileName = nameof(BoolEvent), order = Framework.MenuOrders.Bool)]
    public sealed class BoolEvent : Event<bool>
    {
    }
}