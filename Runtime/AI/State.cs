using UnityEngine;
using UnityEngine.Events;

namespace SODD.AI
{
    [AddComponentMenu(Framework.State, Framework.MenuOrders.State)]
    public sealed class State : MonoBehaviour
    {
        [SerializeField] private UnityEvent onEnter;
        [SerializeField] private UnityEvent onExit;

        public void Enter()
        {
            gameObject.SetActive(true);
            onEnter?.Invoke();
        }

        public void Exit()
        {
            gameObject.SetActive(false);
            onExit?.Invoke();
        }
    }
}