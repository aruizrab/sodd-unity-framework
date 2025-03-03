using SODD.Core;
using SODD.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace SODD.AI
{
    /// <summary>
    ///     Detects collisions and triggers events when objects collide.
    /// </summary>
    /// <remarks>
    ///     The <see cref="CollisionDetector" /> class is responsible for detecting collisions and invoking corresponding
    ///     events.
    ///     It supports detection for both regular and trigger colliders, making it versatile for various collision detection
    ///     scenarios.
    /// </remarks>
    public class CollisionDetector : MonoBehaviour
    {
        [SerializeField] private ValueReference<LayerMask> targetLayers;
        [SerializeField] private CollisionDetectionStrategy detectionStrategy;
        [SerializeField] private UnityEvent<GameObject> onCollisionEnter;
        [SerializeField] private UnityEvent<GameObject> onCollisionExit;

        /// <summary>
        ///     Invoked when a collision starts.
        /// </summary>
        /// <param name="other">The collision data associated with the collision event.</param>
        private void OnCollisionEnter(Collision other)
        {
            if (detectionStrategy.HasFlag(CollisionDetectionStrategy.Colliders)) OnEnter(other.gameObject);
        }

        /// <summary>
        ///     Invoked when a collision ends.
        /// </summary>
        /// <param name="other">The collision data associated with the collision event.</param>
        private void OnCollisionExit(Collision other)
        {
            if (detectionStrategy.HasFlag(CollisionDetectionStrategy.Colliders)) OnExit(other.gameObject);
        }

        /// <summary>
        ///     Invoked when a trigger collider is entered.
        /// </summary>
        /// <param name="other">The collider involved in the trigger event.</param>
        private void OnTriggerEnter(Collider other)
        {
            if (detectionStrategy.HasFlag(CollisionDetectionStrategy.TriggerColliders)) OnEnter(other.gameObject);
        }

        /// <summary>
        ///     Invoked when a trigger collider is exited.
        /// </summary>
        /// <param name="other">The collider involved in the trigger event.</param>
        private void OnTriggerExit(Collider other)
        {
            if (detectionStrategy.HasFlag(CollisionDetectionStrategy.TriggerColliders)) OnExit(other.gameObject);
        }

        private void OnEnter(GameObject obj)
        {
            if (obj.IsInLayerMask(targetLayers.Value)) onCollisionEnter?.Invoke(obj);
        }

        private void OnExit(GameObject obj)
        {
            if (obj.IsInLayerMask(targetLayers.Value)) onCollisionExit?.Invoke(obj);
        }
    }
}