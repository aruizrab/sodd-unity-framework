using System.Collections.Generic;
using System.Linq;
using SODD.Attributes;
using SODD.Core;
using UnityEngine;

namespace SODD.AI
{
    [AddComponentMenu(Framework.StateMachine, Framework.MenuOrders.StateMachine)]
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private State initialState;
        [SerializeField] [Disabled] private State currentState;
        [SerializeField] private List<State> states;
        [SerializeField] private List<State> stateQueue;

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
            states
                .Where(state => !state.Equals(initialState))
                .ForEach(state => state.gameObject.SetActive(false));

            CurrentState = initialState;
        }

        private void OnDisable()
        {
            if (currentState) currentState.Exit();
        }

        public void AddFirstToQueue(State state)
        {
            stateQueue.Insert(0, state);
        }

        public void AddLastToQueue(State state)
        {
            stateQueue.Add(state);
        }

        public void ConsumeFirstFromQueue()
        {
            if (!stateQueue.Any()) return;
            var state = stateQueue[0];
            stateQueue.RemoveAt(0);
            CurrentState = state;
        }

        public void ConsumeLastFromQueue()
        {
            if (!stateQueue.Any()) return;
            var lastIndex = stateQueue.Count - 1;
            var state = stateQueue[lastIndex];
            stateQueue.RemoveAt(lastIndex);
            CurrentState = state;
        }
    }
}