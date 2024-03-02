using UnityEngine;

namespace SODD.Listeners
{
    /// <summary>
    ///     Represents an event listener for Vector3 events.
    /// </summary>
    [AddComponentMenu(Framework.EventListeners.Vector3EventListener, Framework.MenuOrders.Vector3)]
    public class Vector3EventListener : EventListener<Vector3>
    {
    }
}