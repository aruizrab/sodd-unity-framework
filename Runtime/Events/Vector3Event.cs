using UnityEngine;

namespace SODD.Events
{
    /// <summary>
    ///     Represents a scriptable event that carries a Vector3 payload.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This class extends the generic <see cref="Event{T}" /> class, specifying <c>Vector3</c> as the type parameter.
    ///         It is ideal for scenarios involving three-dimensional vectors, such as spatial coordinates for moving objects,
    ///         spawning items, or effects in 3D space.
    ///     </para>
    ///     <para>
    ///         Typical use cases include determining spawn locations for characters or objects, tracking movement paths, or
    ///         coordinating complex particle effects in response to game actions.
    ///     </para>
    ///     <para>
    ///         This class can be created as a ScriptableObject asset directly from the Unity Editor.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Below is an example demonstrating how to define and use a <see cref="Vector3Event" /> to manage particle spawning
    ///     at specific 3D coordinates:
    ///     <code>
    /// public class ParticleSpawner : MonoBehaviour
    /// {
    ///     public Vector3Event onSpawnParticles; // Assign this through the Unity Editor.
    ///     public ParticleSystem particleSystem; // Assign your Particle System through the Unity Editor.
    /// 
    ///     private void OnEnable()
    ///     {
    ///         onSpawnParticles.AddListener(SpawnParticles);
    ///     }
    /// 
    ///     private void OnDisable()
    ///     {
    ///         onSpawnParticles.RemoveListener(SpawnParticles);
    ///     }
    /// 
    ///     private void SpawnParticles(Vector3 position)
    ///     {
    ///         particleSystem.transform.position = position;
    ///         particleSystem.Emit(10); // Emit 10 particles at the given location
    ///     }
    /// }
    /// </code>
    ///     This example shows how the <c>onSpawnParticles</c> event can be used to spawn particles at specific 3D coordinates
    ///     received through the event, allowing for dynamic effects that are decoupled from the logic that triggers these
    ///     effects.
    /// </example>
    [CreateAssetMenu(menuName = Framework.Events.Vector3, fileName = nameof(Vector3Event), order = Framework.MenuOrders.Vector3)]
    public sealed class Vector3Event : Event<Vector3>
    {
    }
}