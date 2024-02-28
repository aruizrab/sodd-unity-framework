using UnityEngine;

namespace SODD.Listeners
{
    /// <summary>
    ///     Represents an event listener for boolean events.
    /// </summary>
    [AddComponentMenu(Framework.EventListeners.BoolEventListener, Framework.MenuOrders.Bool)]
    public class BoolEventListener : EventListener<bool>
    {
    }
}