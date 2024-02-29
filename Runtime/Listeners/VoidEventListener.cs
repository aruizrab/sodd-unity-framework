using SODD.Core;
using UnityEngine;

namespace SODD.Listeners
{
    /// <summary>
    ///     Represents an event listener for void events.
    /// </summary>
    [AddComponentMenu(Framework.EventListeners.VoidEventListener, Framework.MenuOrders.Void)]
    public class VoidEventListener : EventListener<Void>
    {
    }
}