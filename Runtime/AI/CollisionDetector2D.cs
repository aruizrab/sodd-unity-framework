using SODD.Core;
using SODD.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace SODD.AI
{
    public sealed class CollisionDetector2D: MonoBehaviour
    {
        [SerializeField] private ValueReference<LayerMask> targetLayers;
        [SerializeField] private CollisionDetectionStrategy detectionStrategy;

        public UnityEvent<GameObject> onCollisionEnter;
        public UnityEvent<GameObject> onCollisionExit;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (detectionStrategy.HasFlag(CollisionDetectionStrategy.Colliders)) OnEnter(other.gameObject);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (detectionStrategy.HasFlag(CollisionDetectionStrategy.Colliders)) OnExit(other.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (detectionStrategy.HasFlag(CollisionDetectionStrategy.TriggerColliders)) OnEnter(other.gameObject);
        }

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