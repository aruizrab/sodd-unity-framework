using UnityEngine;

namespace SODD.Collections
{
    /// <summary>
    ///     Represents a collection that stores Objects.
    /// </summary>
    /// <seealso cref="Collection{T}" />
    [CreateAssetMenu(menuName = Framework.Collections.Object, fileName = nameof(ObjectCollection),
        order = Framework.MenuOrders.Object)]
    public sealed class ObjectCollection : Collection<Object>
    {
    }
}