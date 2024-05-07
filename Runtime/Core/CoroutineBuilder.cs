using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace SODD.Core
{
    /// <summary>
    ///     Provides a flexible builder for constructing and managing custom coroutines.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <see cref="CoroutineBuilder" /> class allows developers to dynamically construct coroutines by chaining
    ///         various types of execution steps, such as invoking actions, waiting for seconds, or repeating steps.
    ///         This class simplifies complex coroutine creation and management, making it easy to customize behavior
    ///         at runtime without writing repetitive coroutine functions.
    ///     </para>
    ///     <para>
    ///         It supports conditional waits, loops, and method invocation, providing a powerful tool for creating
    ///         sophisticated asynchronous behaviors.
    ///     </para>
    /// </remarks>
    public class CoroutineBuilder: MonoBehaviour, ICloneable
    {
        private readonly WaitForEndOfFrame _waitForEndOfFrame = new();
        private readonly WaitForFixedUpdate _waitForFixedUpdate = new();
        private Coroutine _coroutine;
        private bool _destroyOnFinish = true, _cancelOnDisable = true;
        private List<ExecutionStep> _steps = new();

        /// <summary>
        ///     Gets a value indicating whether the coroutine is currently running.
        /// </summary>
        public bool IsRunning { get; private set; }

        private void OnDisable()
        {
            if (_cancelOnDisable) Cancel();
        }

        /// <summary>
        ///     Creates a shallow copy of the current <see cref="CoroutineBuilder" /> instance.
        /// </summary>
        /// <returns>A shallow copy of the current <see cref="CoroutineBuilder" /> instance.</returns>
        public object Clone()
        {
            var clone = gameObject.Coroutine(_destroyOnFinish, _cancelOnDisable);

            clone._steps = new List<ExecutionStep>(_steps);

            return clone;
        }

        /// <summary>
        ///     Adds an execution step to invoke the specified action during the coroutine execution.
        /// </summary>
        /// <param name="action">The action to be invoked.</param>
        /// <returns>The current <see cref="CoroutineBuilder" /> instance.</returns>
        public CoroutineBuilder Invoke([NotNull] Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            _steps.Add(new ExecutionStep(StepType.Invoke, action));
            return this;
        }

        /// <summary>
        ///     Adds an execution step to wait for a specified number of seconds during the coroutine execution.
        /// </summary>
        /// <param name="seconds">The number of seconds to wait.</param>
        /// <returns>The current <see cref="CoroutineBuilder" /> instance.</returns>
        public CoroutineBuilder WaitForSeconds(float seconds)
        {
            if (seconds < 0) throw new ArgumentOutOfRangeException(nameof(seconds));
            _steps.Add(new ExecutionStep(StepType.WaitForSeconds, seconds));
            return this;
        }

        /// <summary>
        ///     Adds an execution step to repeat the previous steps a specified number of times during the coroutine execution.
        /// </summary>
        /// <param name="times">The number of times to repeat the previous steps.</param>
        /// <returns>The current <see cref="CoroutineBuilder" /> instance.</returns>
        public CoroutineBuilder ForTimes(int times)
        {
            if (times < 0) throw new ArgumentOutOfRangeException(nameof(times));
            _steps.Add(new ExecutionStep(StepType.ForTimes, times));
            return this;
        }

        /// <summary>
        ///     Adds an execution step to wait while the specified predicate is true during the coroutine execution.
        /// </summary>
        /// <param name="predicate">The predicate function to evaluate.</param>
        /// <returns>The current <see cref="CoroutineBuilder" /> instance.</returns>
        public CoroutineBuilder While([NotNull] Func<bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            _steps.Add(new ExecutionStep(StepType.While, predicate));
            return this;
        }

        /// <summary>
        ///     Adds an execution step to wait for the end of the current frame during the coroutine execution.
        /// </summary>
        /// <returns>The current <see cref="CoroutineBuilder" /> instance.</returns>
        public CoroutineBuilder WaitForEndOfFrame()
        {
            _steps.Add(new ExecutionStep(StepType.WaitForEndOfFrame));
            return this;
        }

        /// <summary>
        ///     Adds an execution step to wait for the next fixed update during the coroutine execution.
        /// </summary>
        /// <returns>The current <see cref="CoroutineBuilder" /> instance.</returns>
        public CoroutineBuilder WaitForFixedUpdate()
        {
            _steps.Add(new ExecutionStep(StepType.WaitForFixedUpdate));
            return this;
        }

        /// <summary>
        ///     Adds an execution step to wait until the specified predicate is true during the coroutine execution.
        /// </summary>
        /// <param name="predicate">The predicate function to evaluate.</param>
        /// <returns>The current <see cref="CoroutineBuilder" /> instance.</returns>
        public CoroutineBuilder WaitUntil([NotNull] Func<bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            _steps.Add(new ExecutionStep(StepType.WaitUntil, predicate));
            return this;
        }

        /// <summary>
        ///     Adds an execution step to wait while the specified predicate is false during the coroutine execution.
        /// </summary>
        /// <param name="predicate">The predicate function to evaluate.</param>
        /// <returns>The current <see cref="CoroutineBuilder" /> instance.</returns>
        public CoroutineBuilder WaitWhile([NotNull] Func<bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            _steps.Add(new ExecutionStep(StepType.WaitWhile, predicate));
            return this;
        }

        /// <summary>
        ///     Configures whether the <see cref="CoroutineBuilder" /> instance should be destroyed when the coroutine finishes.
        /// </summary>
        /// <param name="condition">True if the instance should be destroyed; otherwise, false.</param>
        /// <returns>The current <see cref="CoroutineBuilder" /> instance.</returns>
        public CoroutineBuilder DestroyOnFinish(bool condition = true)
        {
            _destroyOnFinish = condition;
            return this;
        }

        /// <summary>
        ///     Configures whether the <see cref="CoroutineBuilder" /> instance should be canceled when it gets disabled.
        /// </summary>
        /// <param name="condition">True if the instance should be canceled; otherwise, false.</param>
        /// <returns>The current <see cref="CoroutineBuilder" /> instance.</returns>
        public CoroutineBuilder CancelOnDisable(bool condition = true)
        {
            _cancelOnDisable = condition;
            return this;
        }

        /// <summary>
        ///     Appends the specified coroutines to the current <see cref="CoroutineBuilder" /> instance.
        /// </summary>
        /// <param name="coroutines">The coroutines to append.</param>
        /// <returns>The current <see cref="CoroutineBuilder" /> instance.</returns>
        /// <exception cref="System.Exception">Thrown when one of the coroutines is currently running.</exception>
        public CoroutineBuilder Append(params CoroutineBuilder[] coroutines)
        {
            if (IsRunning) throw new Exception("Cannot append coroutines while one of them is running.");
            foreach (var coroutine in coroutines)
            {
                if (coroutine.IsRunning)
                    throw new Exception("Cannot append coroutines while one of them is running.");
                _steps.AddRange(coroutine._steps);
            }

            for (var i = coroutines.Length - 1; i >= 0; i--) Destroy(coroutines[i]);
            return this;
        }

        /// <summary>
        ///     Runs the configured coroutine.
        /// </summary>
        public void Run()
        {
            Cancel();
            _coroutine = StartCoroutine(RunCoroutine());
        }

        /// <summary>
        ///     Cancels the running coroutine.
        /// </summary>
        public void Cancel()
        {
            if (IsRunning)
            {
                StopCoroutine(_coroutine);
                IsRunning = false;
            }

            if (_destroyOnFinish) Destroy(this);
        }

        private IEnumerator RunCoroutine()
        {
            IsRunning = true;

            var iterations = 0;
            var start = 0;

            for (var i = 0; i < _steps.Count; i++)
            {
                var step = _steps.ElementAt(i);

                switch (step.Type)
                {
                    case StepType.Invoke:
                        (step.Value as Action)?.Invoke();
                        break;
                    case StepType.WaitForSeconds:
                        yield return new WaitForSeconds((float)step.Value);
                        break;
                    case StepType.WaitForEndOfFrame:
                        yield return _waitForEndOfFrame;
                        break;
                    case StepType.WaitForFixedUpdate:
                        yield return _waitForFixedUpdate;
                        break;
                    case StepType.WaitUntil:
                        yield return new WaitUntil(step.Value as Func<bool>);
                        break;
                    case StepType.WaitWhile:
                        yield return new WaitWhile(step.Value as Func<bool>);
                        break;
                    case StepType.ForTimes when iterations < (int)step.Value - 1:
                        i = start - 1;
                        iterations++;
                        break;
                    case StepType.ForTimes:
                        iterations = 0;
                        start = i + 1;
                        break;
                    case StepType.While when (step.Value as Func<bool>)?.Invoke() ?? false:
                        i = start - 1;
                        iterations++;
                        break;
                    case StepType.While:
                        iterations = 0;
                        start = i + 1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            IsRunning = false;
            if (_destroyOnFinish) Destroy(this);
        }

        private enum StepType
        {
            Invoke,
            WaitForSeconds,
            WaitForEndOfFrame,
            ForTimes,
            While,
            WaitForFixedUpdate,
            WaitUntil,
            WaitWhile
        }

        private readonly struct ExecutionStep
        {
            public readonly StepType Type;
            public readonly object Value;

            public ExecutionStep(StepType type, object value = null)
            {
                Type = type;
                Value = value;
            }
        }
    }
}