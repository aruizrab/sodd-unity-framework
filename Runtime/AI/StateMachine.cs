using System.Collections.Generic;
using System.Linq;
using SODD.Attributes;
using SODD.Core;
using UnityEngine;

namespace SODD.AI
{
    /// <summary>
    ///     Manages the states in a state machine, handling state transitions and maintaining a state queue.
    /// </summary>
    /// <remarks>
    ///     The <see cref="StateMachine" /> class is responsible for managing the lifecycle of states within a state machine.
    ///     It provides mechanisms to transition between states, queue states for later execution, and maintain the current
    ///     state.
    /// </remarks>
    [AddComponentMenu(Framework.StateMachine, Framework.MenuOrders.StateMachine)]
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private State initialState;
        [SerializeField] [Disabled] private State currentState;
        [SerializeField] private List<State> states;
        [SerializeField] private List<State> stateQueue;

        /// <summary>
        ///     Gets or sets the current state. Exits the previous state and enters the new state.
        /// </summary>
        /// <value>The current state of the state machine.</value>
        /// <remarks>
        ///     When setting the <see cref="CurrentState" />, the state machine exits the previous state (if any) and enters the
        ///     new state.
        ///     If the new state is the same as the current state, no transition occurs.
        /// </remarks>
        public State CurrentState
        {
            get => currentState;
            set
            {
                if (currentState && currentState.Equals(value)) return;
                if (currentState) currentState.Exit();
                currentState = value;
                if (currentState) currentState.Enter();
            }
        }

        private void OnEnable()
        {
            states.Where(state => !state.Equals(initialState)).ForEach(state => state.gameObject.SetActive(false));
            CurrentState = initialState;
        }

        private void OnDisable()
        {
            if (currentState) currentState.Exit();
        }

        /// <summary>
        ///     Adds a state to the beginning of the state queue.
        /// </summary>
        /// <param name="state">The state to add to the queue.</param>
        /// <remarks>
        ///     This method inserts the specified <paramref name="state" /> at the beginning of the state queue.
        ///     The state queue is processed in a first-in-first-out (FIFO) manner.
        /// </remarks>
        public void AddFirstToQueue(State state)
        {
            stateQueue.Insert(0, state);
        }

        /// <summary>
        ///     Adds a state to the end of the state queue.
        /// </summary>
        /// <param name="state">The state to add to the queue.</param>
        /// <remarks>
        ///     This method appends the specified <paramref name="state" /> to the end of the state queue.
        ///     The state queue is processed in a first-in-first-out (FIFO) manner.
        /// </remarks>
        public void AddLastToQueue(State state)
        {
            stateQueue.Add(state);
        }

        /// <summary>
        ///     Sets the current state to the first state in the queue and removes it from the queue.
        /// </summary>
        /// <remarks>
        ///     This method transitions the state machine to the first state in the queue and removes that state from the queue.
        ///     If the queue is empty, no state transition occurs.
        /// </remarks>
        public void ConsumeFirstFromQueue()
        {
            if (!stateQueue.Any()) return;
            var state = stateQueue[0];
            stateQueue.RemoveAt(0);
            CurrentState = state;
        }

        /// <summary>
        ///     Sets the current state to the last state in the queue and removes it from the queue.
        /// </summary>
        /// <remarks>
        ///     This method transitions the state machine to the last state in the queue and removes that state from the queue.
        ///     If the queue is empty, no state transition occurs.
        /// </remarks>
        public void ConsumeLastFromQueue()
        {
            if (!stateQueue.Any()) return;
            var lastIndex = stateQueue.Count - 1;
            var state = stateQueue[lastIndex];
            stateQueue.RemoveAt(lastIndex);
            CurrentState = state;
        }

        /// <summary>
        ///     Adds the current state to the end of the state queue.
        /// </summary>
        /// <remarks>
        ///     This method appends the current state of the state machine to the end of the state queue.
        /// </remarks>
        public void AddCurrentStateLastToQueue()
        {
            AddLastToQueue(currentState);
        }

        /// <summary>
        ///     Adds the current state to the beginning of the state queue.
        /// </summary>
        /// <remarks>
        ///     This method inserts the current state of the state machine at the beginning of the state queue.
        /// </remarks>
        public void AddCurrentStateFirstToQueue()
        {
            AddFirstToQueue(currentState);
        }
    }
}