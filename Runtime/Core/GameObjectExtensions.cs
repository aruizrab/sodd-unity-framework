using UnityEngine;

namespace SODD.Core
{
    public static class GameObjectExtensions
    {
        /// <summary>
        ///     Creates and attaches a <see cref="CoroutineBuilder" /> to this <see cref="GameObject" />.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject" /> on which to create the <see cref="CoroutineBuilder" />.</param>
        /// <param name="destroyOnFinish">
        ///     If set to true, the <see cref="CoroutineBuilder" /> will be automatically destroyed when the coroutine execution
        ///     completes.
        /// </param>
        /// <param name="cancelOnDisable">
        ///     If set to true, the coroutine execution will be automatically canceled if the <see cref="GameObject" /> is
        ///     disabled.
        /// </param>
        /// <returns>
        ///     A <see cref="CoroutineBuilder" /> attached to this <see cref="GameObject" />.
        /// </returns>
        /// <remarks>
        ///     This method dynamically adds a new <see cref="CoroutineBuilder" /> component to the specified
        ///     <see cref="GameObject" />. It is ideal for situations where
        ///     the behavior of the <see cref="GameObject" /> needs to be extended with custom asynchronous routines that can be
        ///     defined on-the-fly using method chaining.
        ///     The <see cref="CoroutineBuilder" /> supports various types of execution steps like delays, loops, and
        ///     condition-based continuations, making it versatile for complex asynchronous behaviors.
        /// </remarks>
        /// <example>
        ///     <code>
        /// // Create a coroutine that waits 2 seconds, then logs a message to the console
        /// gameObject.Coroutine()
        ///     .WaitForSeconds(2)
        ///     .Invoke(() => Debug.Log("2 seconds have passed"))
        ///     .Run();
        /// </code>
        /// </example>
        public static CoroutineBuilder Coroutine(this GameObject gameObject, bool destroyOnFinish = true,
            bool cancelOnDisable = true)
        {
            var coroutineBuilder = gameObject.AddComponent<CoroutineBuilder>()
                .DestroyOnFinish(destroyOnFinish)
                .CancelOnDisable(cancelOnDisable);
            coroutineBuilder.hideFlags = HideFlags.HideInInspector;
            return coroutineBuilder;
        }
    }
}