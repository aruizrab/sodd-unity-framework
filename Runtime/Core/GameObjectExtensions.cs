using UnityEngine;

namespace SODD.Core
{
    /// <summary>
    ///     Extends <see cref="GameObject" /> type providing utility methods.
    /// </summary>
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

        /// <summary>
        ///     Determines whether the <see cref="GameObject" /> is part of the specified <see cref="LayerMask" />.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject" /> to test.</param>
        /// <param name="layerMask">The <see cref="LayerMask" /> to check against.</param>
        /// <returns><c>true</c> if the gameObject's layer is included in the layerMask; otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     This method checks if the layer to which the gameObject belongs is included in the specified layerMask.
        ///     It uses bitwise operations to compare the gameObject's layer with the layerMask.
        /// </remarks>
        /// <example>
        ///     This example demonstrates how to check if a GameObject named "Player" is in a LayerMask defined for enemies:
        ///     <code>
        /// GameObject player = GameObject.Find("Player");
        /// LayerMask enemyLayerMask = LayerMask.GetMask("Enemy");
        /// 
        /// bool isPlayerInEnemyLayer = player.IsInLayerMask(enemyLayerMask);
        /// 
        /// if (isPlayerInEnemyLayer)
        /// {
        ///     Debug.Log("Player is in the Enemy Layer.");
        /// }
        /// else
        /// {
        ///     Debug.Log("Player is not in the Enemy Layer.");
        /// }
        /// </code>
        /// </example>
        public static bool IsInLayerMask(this GameObject gameObject, LayerMask layerMask)
        {
            return layerMask == (layerMask | (1 << gameObject.layer));
        }
    }
}