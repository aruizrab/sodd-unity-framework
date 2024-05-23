using UnityEngine;
using UnityEngine.Events;

namespace SODD.Core
{
    [AddComponentMenu(Framework.LifecycleEvents, Framework.MenuOrders.LifecycleEvents)]
    public class LifecycleEvents : MonoBehaviour
    {
        [SerializeField] private UnityEvent onAwake;
        [SerializeField] private UnityEvent onStart;
        [SerializeField] private UnityEvent onEnable;
        [SerializeField] private UnityEvent onDisable;
        [SerializeField] private UnityEvent onDestroy;

        private void Awake()
        {
            onAwake?.Invoke();
        }

        private void Start()
        {
            onStart?.Invoke();
        }

        private void OnEnable()
        {
            onEnable?.Invoke();
        }

        private void OnDisable()
        {
            onDisable?.Invoke();
        }

        private void OnDestroy()
        {
            onDestroy?.Invoke();
        }
    }
}