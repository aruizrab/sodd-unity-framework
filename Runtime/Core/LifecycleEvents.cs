using UnityEngine;
using UnityEngine.Events;

namespace SODD.Core
{
    /// <summary>
    ///     Invokes Unity events corresponding to the lifecycle events of a Unity MonoBehaviour.
    /// </summary>
    /// <remarks>
    ///     The <see cref="LifecycleEvents" /> class is used to hook into the lifecycle events of a Unity MonoBehaviour.
    ///     It provides Unity events for Awake, Start, OnEnable, OnDisable, and OnDestroy, allowing for flexible event-driven
    ///     programming within the Unity Editor.
    /// </remarks>
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