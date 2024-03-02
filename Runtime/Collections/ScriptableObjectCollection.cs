using UnityEngine;

namespace SODD.Collections
{
    /// <summary>
    ///     Represents a collection that stores ScriptableObjects.
    /// </summary>
    /// <seealso cref="Collection{T}" />
    [CreateAssetMenu(menuName = Framework.Collections.ScriptableObject, fileName = nameof(ScriptableObjectCollection),
        order = Framework.MenuOrders.ScriptableObject)]
    public sealed class ScriptableObjectCollection : Collection<ScriptableObject>
    {
    }
}