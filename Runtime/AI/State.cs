using UnityEngine;
using UnityEngine.Events;

namespace SODD.AI
{
    /// <summary>
    ///     Represents a state in a state machine, managing its entry and exit logic.
    /// </summary>
    /// <remarks>
    ///     The <see cref="State" /> class is used within a state machine to define specific states and their associated
    ///     behaviors.
    ///     Each state can execute actions upon entering and exiting, which are managed by Unity events.
    /// </remarks>
    [AddComponentMenu(Framework.State, Framework.MenuOrders.State)]
    public sealed class State : MonoBehaviour
    {
        /// <summary>
        ///     Invoked when the state is entered.
        /// </summary>
        /// <remarks>
        ///     This event is triggered when the state machine transitions into this state. You can use this event to
        ///     perform any initialization or setup required when entering the state.
        /// </remarks>
        [SerializeField] private UnityEvent onEnter;

        /// <summary>
        ///     Invoked when the state is exited.
        /// </summary>
        /// <remarks>
        ///     This event is triggered when the state machine transitions out of this state. You can use this event to
        ///     perform any cleanup or teardown required when exiting the state.
        /// </remarks>
        [SerializeField] private UnityEvent onExit;

        /// <summary>
        ///     Activates the state and invokes the <see cref="onEnter" /> event.
        /// </summary>
        /// <remarks>
        ///     This method sets the game object associated with the state to active and triggers any actions associated with
        ///     entering the state.
        ///     It is typically called by the state machine managing this state.
        /// </remarks>
        public void Enter()
        {
            gameObject.SetActive(true);
            onEnter?.Invoke();
        }

        /// <summary>
        ///     Deactivates the state and invokes the <see cref="onExit" /> event.
        /// </summary>
        /// <remarks>
        ///     This method sets the game object associated with the state to inactive and triggers any actions associated with
        ///     exiting the state.
        ///     It is typically called by the state machine managing this state.
        /// </remarks>
        public void Exit()
        {
            gameObject.SetActive(false);
            onExit?.Invoke();
        }
    }
}