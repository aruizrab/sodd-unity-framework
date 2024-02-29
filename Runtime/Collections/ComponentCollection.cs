using UnityEngine;

namespace SODD.Collections
{
    /// <summary>
    ///     Represents a collection that stores Components.
    /// </summary>
    /// <seealso cref="Collection{T}" />
    [CreateAssetMenu(menuName = Framework.Collections.Component, fileName = nameof(ComponentCollection),
        order = Framework.MenuOrders.Component)]
    public sealed class ComponentCollection : Collection<Component>
    {
    }
}