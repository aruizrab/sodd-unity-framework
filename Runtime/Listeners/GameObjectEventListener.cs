using UnityEngine;

namespace SODD.Listeners
{
    /// <summary>
    ///     Represents an event listener for GameObject events.
    /// </summary>
    [AddComponentMenu(Framework.EventListeners.GameObjectEventListener, Framework.MenuOrders.GameObject)]
    public class GameObjectEventListener : EventListener<GameObject>
    {
    }
}