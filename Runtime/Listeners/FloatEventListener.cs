using UnityEngine;

namespace SODD.Listeners
{
    /// <summary>
    ///     Represents an event listener for float events.
    /// </summary>
    [AddComponentMenu(Framework.EventListeners.FloatEventListener, Framework.MenuOrders.Float)]
    public class FloatEventListener : EventListener<float>
    {
    }
}