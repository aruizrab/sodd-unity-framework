using UnityEngine;

namespace SODD.Collections
{
    /// <summary>
    ///     Represents a scriptable collection that stores Unity Components.
    /// </summary>
    /// <remarks>
    ///     This collection provides a concrete implementation of the abstract <see cref="Collection{T}" /> class,
    ///     specifically designed for managing Unity Components. It enables the structured and dynamic management
    ///     of components within a game, facilitating operations like adding, removing, or iterating over components
    ///     without requiring direct management by other objects.
    ///     An essential use of this collection is in scenarios where components need to be managed independently
    ///     of the objects that use them, enhancing modularity and reducing coupling in game architecture.
    /// </remarks>
    /// <example>
    ///     Example of using <see cref="ComponentCollection" /> to manage explosives in a game:
    ///     <code>
    /// public class Detonator : MonoBehaviour
    /// {
    ///     public ComponentCollection placedExplosives; // Assign this via the Unity Editor.
    ///     public VoidEvent onDetonateExplosives;
    /// 
    ///     private void OnEnable()
    ///     {
    ///         onDetonateExplosives.AddListener(DetonateExplosives);
    ///     }
    /// 
    ///     private void OnDisable()
    ///     {
    ///         onDetonateExplosives.RemoveListener(DetonateExplosives);
    ///     }
    /// 
    ///     private void DetonateExplosives(Void o)
    ///     {
    ///         foreach (var component in placedExplosives)
    ///         {
    ///             var explosive = (Explosive) component;
    ///             explosive.Detonate();
    ///         }
    ///         placedExplosives.Clear();
    ///     }
    /// }
    /// </code>
    ///     This script shows how explosives can dynamically add themselves to the 'placedExplosives' collection
    ///     when instantiated and how a detonator can trigger their detonation without needing to directly gather or
    ///     reference individual explosives. This allows the detonator to operate independently of the explosives' management.
    /// </example>
    [CreateAssetMenu(menuName = Framework.Collections.Component, fileName = nameof(ComponentCollection),
        order = Framework.MenuOrders.Component)]
    public sealed class ComponentCollection : Collection<Component>
    {
    }
}