using UnityEngine;

namespace SODD.Events
{
    /// <summary>
    ///     A ScriptableObject that represents an event carrying an GameObject payload.
    /// </summary>
    /// <seealso cref="Event{T}" />
    [CreateAssetMenu(menuName = Framework.Events.GameObject, fileName = nameof(GameObjectEvent), order = Framework.MenuOrders.GameObject)]
    public sealed class GameObjectEvent : Event<GameObject>
    {
    }
}