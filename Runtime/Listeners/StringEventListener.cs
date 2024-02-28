using UnityEngine;

namespace SODD.Listeners
{
    /// <summary>
    ///     Represents an event listener for string events.
    /// </summary>
    [AddComponentMenu(Framework.EventListeners.StringEventListener, Framework.MenuOrders.String)]
    public class StringEventListener : EventListener<string>
    {
    }
}