using UnityEngine;

namespace SODD.Collections
{
    /// <summary>
    ///     Represents a collection that stores GameObjects.
    /// </summary>
    /// <seealso cref="Collection{T}" />
    [CreateAssetMenu(menuName = Framework.Collections.GameObject, fileName = nameof(GameObjectCollection),
        order = Framework.MenuOrders.GameObject)]
    public sealed class GameObjectCollection : Collection<GameObject>
    {
    }
}