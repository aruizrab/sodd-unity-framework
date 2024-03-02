using UnityEngine;

namespace SODD.Listeners
{
    /// <summary>
    ///     Represents an event listener for integer events.
    /// </summary>
    [AddComponentMenu(Framework.EventListeners.IntEventListener, Framework.MenuOrders.Int)]
    public class IntEventListener : EventListener<int>
    {
    }
}