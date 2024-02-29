using UnityEngine;
using Void = SODD.Core.Void;

namespace SODD.Events
{
    /// <summary>
    ///     A ScriptableObject that represents an event carrying no payload.
    /// </summary>
    /// <seealso cref="Event{T}" />
    [CreateAssetMenu(menuName = Framework.Events.Void, fileName = nameof(VoidEvent), order = Framework.MenuOrders.Void)]
    public sealed class VoidEvent : Event<Void>
    {
        public void Invoke()
        {
            Invoke(Void.Instance);
        }
    }
}