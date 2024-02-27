using UnityEngine;

namespace SODD.Events
{
    /// <summary>
    ///     A ScriptableObject that represents an event carrying an integer payload.
    /// </summary>
    /// <seealso cref="Event{T}" />
    [CreateAssetMenu(menuName = Framework.Events.Int, fileName = nameof(IntEvent), order = Framework.MenuOrders.Int)]
    public sealed class IntEvent : Event<int>
    {
    }
}