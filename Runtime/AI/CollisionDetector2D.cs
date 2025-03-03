using SODD.Core;
using SODD.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace SODD.AI
{
    /// <summary>
    ///     Detects 2D collisions and triggers events when objects collide.
    /// </summary>
    /// <remarks>
    ///     The <see cref="CollisionDetector2D" /> class is responsible for detecting 2D collisions and invoking corresponding
    ///     events.
    ///     It supports detection for both regular and trigger colliders in a 2D environment, making it versatile for various
    ///     collision detection scenarios.
    /// </remarks>
    public sealed class CollisionDetector2D : MonoBehaviour
    {
        [SerializeField] private ValueReference<LayerMask> targetLayers;
        [SerializeField] private CollisionDetectionStrategy detectionStrategy;
        [SerializeField] private UnityEvent<GameObject> onCollisionEnter;
        [SerializeField] private UnityEvent<GameObject> onCollisionExit;

        /// <summary>
        ///     Invoked when a 2D collision starts.
        /// </summary>
        /// <param name="other">The collision data associated with the collision event.</param>
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (detectionStrategy.HasFlag(CollisionDetectionStrategy.Colliders)) OnEnter(other.gameObject);
        }

        /// <summary>
        ///     Invoked when a 2D collision ends.
        /// </summary>
        /// <param name="other">The collision data associated with the collision event.</param>
        private void OnCollisionExit2D(Collision2D other)
        {
            if (detectionStrategy.HasFlag(CollisionDetectionStrategy.Colliders)) OnExit(other.gameObject);
        }

        /// <summary>
        ///     Invoked when a trigger collider is entered.
        /// </summary>
        /// <param name="other">The collider involved in the trigger event.</param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (detectionStrategy.HasFlag(CollisionDetectionStrategy.TriggerColliders)) OnEnter(other.gameObject);
        }

        /// <summary>
        ///     Invoked when a trigger collider is exited.
        /// </summary>
        /// <param name="other">The collider involved in the trigger event.</param>
        private void OnTriggerExit2D(Collider2D other)
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