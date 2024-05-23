using SODD.Core;
using SODD.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace SODD.AI
{
    public class CollisionDetector : MonoBehaviour
    {
        [SerializeField] private ValueReference<LayerMask> targetLayers;
        [SerializeField] private CollisionDetectionStrategy detectionStrategy;
        [SerializeField] private UnityEvent<GameObject> onCollisionEnter;
        [SerializeField] private UnityEvent<GameObject> onCollisionExit;

        private void OnCollisionEnter(Collision other)
        {
            if (detectionStrategy.HasFlag(CollisionDetectionStrategy.Colliders)) OnEnter(other.gameObject);
        }

        private void OnCollisionExit(Collision other)
        {
            if (detectionStrategy.HasFlag(CollisionDetectionStrategy.Colliders)) OnExit(other.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (detectionStrategy.HasFlag(CollisionDetectionStrategy.TriggerColliders)) OnEnter(other.gameObject);
        }

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