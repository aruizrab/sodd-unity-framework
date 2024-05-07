using System;
using System.Linq;
using JetBrains.Annotations;
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

        /// <summary>
        ///     Retrieves a component of type <typeparamref name="T" /> from the specified <see cref="GameObject" /> according to
        ///     the provided <paramref name="scope" />.
        /// </summary>
        /// <typeparam name="T">The type of the component to retrieve.</typeparam>
        /// <param name="gameObject">The <see cref="GameObject" /> from which the component is to be retrieved.</param>
        /// <param name="scope">
        ///     The scope of the search for the component, which can be limited to the GameObject, its children,
        ///     its parent, or both its parent and children. The default value is <see cref="Scope.GameObject" />.
        /// </param>
        /// <returns>
        ///     The component of type <typeparamref name="T" /> found within the specified <paramref name="scope" /> or <c>null</c>
        ///     if no such component exists.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if the <paramref name="scope" /> is not one of the enumerated
        ///     values.
        /// </exception>
        /// <remarks>
        ///     This method allows for a flexible component search by specifying a <paramref name="scope" /> for the search area:
        ///     <list type="bullet">
        ///         <item>
        ///             <description><c>GameObject</c>: Searches only on the given GameObject.</description>
        ///         </item>
        ///         <item>
        ///             <description><c>Children</c>: Searches all children of the GameObject, not including itself.</description>
        ///         </item>
        ///         <item>
        ///             <description><c>Parents</c>: Searches the parent objects of the GameObject, moving up the hierarchy.</description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <c>ParentsAndChildren</c>: First searches up the parent chain, and if no component is found,
        ///                 searches down through the children.
        ///             </description>
        ///         </item>
        ///     </list>
        /// </remarks>
        /// <example>
        ///     <code>
        /// // Retrieve a Rigidbody component only from the GameObject itself
        /// Rigidbody rb = gameObject.GetComponent&lt;Rigidbody&gt;();
        /// 
        /// // Retrieve a Rigidbody component from the children
        /// Rigidbody rbChild = gameObject.GetComponent&lt;Rigidbody&gt;(Scope.Children);
        /// 
        /// // Retrieve a Rigidbody component from the parent or children
        /// Rigidbody rbFamily = gameObject.GetComponent&lt;Rigidbody&gt;(Scope.ParentsAndChildren);
        /// </code>
        ///     This example demonstrates how to retrieve a Rigidbody component from a GameObject with different scopes of search.
        /// </example>
        public static T GetComponent<T>(this GameObject gameObject, Scope scope = Scope.GameObject)
        {
            return scope switch
            {
                Scope.GameObject => gameObject.GetComponent<T>(),
                Scope.Children => gameObject.GetComponentInChildren<T>(),
                Scope.Parents => gameObject.GetComponentInParent<T>(),
                Scope.ParentsAndChildren => gameObject.GetComponentInParent<T>() ??
                                            gameObject.GetComponentInChildren<T>(),
                _ => throw new ArgumentOutOfRangeException(nameof(scope), scope, null)
            };
        }

        /// <summary>
        ///     Retrieves all components of type <typeparamref name="T" /> from the specified <see cref="GameObject" /> according
        ///     to the provided <paramref name="scope" />.
        /// </summary>
        /// <typeparam name="T">The type of the components to retrieve.</typeparam>
        /// <param name="gameObject">The <see cref="GameObject" /> from which the components are to be retrieved.</param>
        /// <param name="scope">
        ///     The scope of the search for the components, which can be limited to the GameObject, its children,
        ///     its parent, or both its parent and children. The default is <see cref="Scope.GameObject" />.
        /// </param>
        /// <returns>
        ///     An array of components of type <typeparamref name="T" /> found within the specified <paramref name="scope" />.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if the <paramref name="scope" /> is not one of the enumerated
        ///     values.
        /// </exception>
        /// <remarks>
        ///     This method expands the capabilities of the standard <see cref="GameObject.GetComponent{T}" /> method by allowing
        ///     the search
        ///     for components to be scoped more broadly than just the current GameObject. Depending on the
        ///     <paramref name="scope" /> parameter,
        ///     components can be retrieved from:
        ///     <list type="bullet">
        ///         <item>
        ///             <description>The GameObject itself (<see cref="Scope.GameObject" />).</description>
        ///         </item>
        ///         <item>
        ///             <description>All direct and indirect children of the GameObject (<see cref="Scope.Children" />).</description>
        ///         </item>
        ///         <item>
        ///             <description>The parent and all higher ancestors of the GameObject (<see cref="Scope.Parents" />).</description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 Both the parent hierarchy and the children hierarchy (<see cref="Scope.ParentsAndChildren" />
        ///                 ), ensuring a unique set of components by removing duplicates.
        ///             </description>
        ///         </item>
        ///     </list>
        ///     This method is particularly useful for complex GameObject hierarchies where a single GameObject may interact with
        ///     multiple related components spread across different levels of the hierarchy.
        /// </remarks>
        /// <example>
        ///     <code>
        ///  // Retrieve all Rigidbody components only from the GameObject itself
        ///  Rigidbody[] rigidbodies = gameObject.GetComponents&lt;Rigidbody&gt;();
        ///  
        ///  // Retrieve all Rigidbody components from the children
        ///  Rigidbody[] childRigidbodies = gameObject.GetComponents&lt;Rigidbody&gt;(Scope.Children);
        ///  
        ///  // Retrieve all unique Rigidbody components from both the parent and children
        ///  Rigidbody[] familyRigidbodies = gameObject.GetComponents&lt;Rigidbody&gt;(Scope.ParentsAndChildren);
        ///  </code>
        ///     <para>
        ///         This example demonstrates how to retrieve Rigidbody components from a GameObject with different scopes of
        ///         search.
        ///     </para>
        /// </example>
        public static T[] GetComponents<T>(this GameObject gameObject, Scope scope = Scope.GameObject)
        {
            return scope switch
            {
                Scope.GameObject => gameObject.GetComponents<T>(),
                Scope.Children => gameObject.GetComponentsInChildren<T>(),
                Scope.Parents => gameObject.GetComponentsInParent<T>(),
                Scope.ParentsAndChildren => gameObject.GetComponentsInParent<T>()
                    .Concat(gameObject.GetComponentsInChildren<T>()).Distinct().ToArray(),
                _ => throw new ArgumentOutOfRangeException(nameof(scope), scope, null)
            };
        }

        /// <summary>
        ///     W
        ///     Tries to retrieve a component of type <typeparamref name="T" /> from the specified <paramref name="gameObject" />
        ///     according to the provided <paramref name="scope" />, and outputs the result.
        /// </summary>
        /// <typeparam name="T">The type of the component to retrieve.</typeparam>
        /// <param name="gameObject">The <see cref="GameObject" /> from which to retrieve the component.</param>
        /// <param name="component">
        ///     When this method returns, contains the component of type <typeparamref name="T" /> if found,
        ///     otherwise null. This parameter is passed uninitialized.
        /// </param>
        /// <param name="scope">
        ///     The <see cref="Scope" /> within which to search for the component. The default is
        ///     <see cref="Scope.GameObject" />.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if a component of type <typeparamref name="T" /> is found; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        /// <remarks>
        ///     This method extends <see cref="GameObject" /> and utilizes <see cref="GameObject.GetComponent{T}" /> to attempt to
        ///     retrieve a component
        ///     of the specified type T. If the component exists within the given scope on the GameObject,
        ///     it is assigned to the output parameter 'component', and the method returns true. If no such component
        ///     is found, the method returns false.
        /// </remarks>
        /// <example>
        ///     The following example demonstrates how to use the <see cref="TryGetComponent{T}" /> method to attempt to retrieve a
        ///     component of type <c>MeshRenderer</c> from a game object.
        ///     <code>
        /// MeshRenderer renderer;
        /// 
        /// if (gameObject.TryGetComponent&lt;MeshRenderer&gt;(out renderer))
        /// {
        ///     Console.WriteLine("Component found!");
        /// }
        /// else
        /// {
        ///     Console.WriteLine("Component not found.");
        /// }
        /// </code>
        /// </example>
        public static bool TryGetComponent<T>(this GameObject gameObject, out T component,
            Scope scope = Scope.GameObject)
        {
            component = gameObject.GetComponent<T>(scope);
            return component != null;
        }

        /// <summary>
        ///     Executes the provided <see cref="Action{T}" /> on the first <typeparamref name="T" /> component found on the
        ///     specified <paramref name="gameObject" />
        ///     within the defined <paramref name="scope" />.
        /// </summary>
        /// <param name="gameObject">The GameObject from which the component is to be retrieved and the action is to be executed.</param>
        /// <param name="action">
        ///     The action to execute on the retrieved component. If the component is not found, the action is not
        ///     executed.
        /// </param>
        /// <param name="scope">
        ///     The <see cref="Scope" /> defining where to search for the component. The default scope is
        ///     <see cref="Scope.GameObject" />.
        /// </param>
        /// <typeparam name="T">The type of the component to retrieve and act upon.</typeparam>
        /// <remarks>
        ///     <para>
        ///         This method offers a robust and more efficient alternative to Unity's <c>SendMessage</c>, which relies on
        ///         string method names and lacks type safety. By directly invoking a delegate on the component,
        ///         <c>Send</c> avoids the overhead and errors associated with string-based method invocation.
        ///     </para>
        ///     <para>
        ///         This method attempts to find a component of type <typeparamref name="T" /> on the
        ///         <paramref name="gameObject" />
        ///         according to the specified <paramref name="scope" />.
        ///         If the component is found, the provided <paramref name="action" /> is executed with the component as its
        ///         argument.
        ///         If no such component is found, or if <paramref name="action" />
        ///         is null, no action is executed.
        ///     </para>
        ///     <para>
        ///         This method is useful for applying operations to components when the exact presence of the component is not
        ///         guaranteed, or when the operation should only be applied conditionally
        ///         based on the presence of the component.
        ///     </para>
        /// </remarks>
        /// <example>
        ///     The following example shows the use of <c>Send</c> to apply damage to a damageable component upon projectile
        ///     impact:
        ///     <code>
        /// public class Projectile : MonoBehaviour
        /// {
        ///     public float damage;
        ///     public LayerMask targetLayers;
        ///     public Event&lt;Vector3&gt; onProjectileImpact;
        /// 
        ///     private void OnCollisionEnter(Collision other)
        ///     {
        ///         if (other.gameObject.IsInLayerMask(targetLayers))
        ///         {
        ///             other.gameObject.Send&lt;IDamageable&gt;(damageable =&gt; damageable.ReceiveDamage(damage));
        ///             onProjectileImpact.Invoke(transform.position);
        ///             Destroy(gameObject);
        ///         }
        ///     }
        /// }
        /// </code>
        ///     This example shows how the <c>Send</c> method is used within the <c>Projectile</c> class to find and interact with
        ///     an <c>IDamageable</c> component on a collision object,
        ///     applying damage and triggering an event upon impact.
        /// </example>
        public static void Send<T>(this GameObject gameObject, Action<T> action, Scope scope = Scope.GameObject)
        {
            if (gameObject.TryGetComponent(out T t, scope)) action?.Invoke(t);
        }
        
        /// <summary>
        /// Executes the provided <see cref="Action{T}"/> on all components of type <typeparamref name="T"/> found on the specified <paramref name="gameObject"/>
        /// within the defined <paramref name="scope"/>.
        /// </summary>
        /// <param name="gameObject">The GameObject from which the components are to be retrieved and the action is to be executed on each.</param>
        /// <param name="action">The action to execute on each retrieved component. If no components are found, the action is not executed.</param>
        /// <param name="scope">
        /// The <see cref="Scope"/> defining where to search for the components. The default is <see cref="Scope.GameObject"/>.
        /// </param>
        /// <typeparam name="T">The type of the components to retrieve and act upon.</typeparam>
        /// <remarks>
        /// This method facilitates the application of a single action to multiple components of the same type distributed throughout the specified scope.
        /// It is particularly useful for scenarios where a uniform operation needs to be applied to an array of components, such as enabling, disabling, or resetting component states.
        /// </remarks>
        /// <example>
        /// The following example shows the use of <c>Broadcast</c> to disable all Collider components within and including children of a GameObject:
        /// <code>
        /// public class ExampleUsage : MonoBehaviour
        /// {
        ///     void Start()
        ///     {
        ///         gameObject.Broadcast&lt;Collider&gt;(collider =&gt; collider.enabled = false, Scope.Children);
        ///     }
        /// }
        /// </code>
        /// </example>
        public static void Broadcast<T>(this GameObject gameObject, Action<T> action, Scope scope = Scope.GameObject)
        {
            foreach (var component in gameObject.GetComponents<T>(scope)) action?.Invoke(component);
        }
        
        /// <summary>
        ///     Calculates the direction vector from the GameObject's position to the specified point.
        /// </summary>
        /// <param name="gameObject">The GameObject to calculate the vector from.</param>
        /// <param name="point">The target point to which the direction vector is calculated.</param>
        /// <returns>
        ///     A Vector3 representing the direction vector from the GameObject's position to the specified point.
        /// </returns>
        /// <remarks>
        ///     This method calculates the direction vector from the GameObject's position to the specified point.
        ///     It uses the GameObject's current position as the starting point and the specified point as the target.
        ///     The resulting direction vector points from the GameObject towards the specified point.
        /// </remarks>
        public static Vector3 VectorTo(this GameObject gameObject, Vector3 point)
        {
            return gameObject.transform.position.VectorTo(point);
        }

        /// <summary>
        ///     Calculates the direction vector from the GameObject's position to the position of the specified Transform.
        /// </summary>
        /// <param name="gameObject">The GameObject to calculate the vector from.</param>
        /// <param name="transform">The Transform whose position is the target of the direction vector.</param>
        /// <returns>
        ///     A Vector3 representing the direction vector from the GameObject's position to the position of the specified
        ///     Transform.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the specified Transform is null.</exception>
        /// <remarks>
        ///     This method calculates the direction vector from the GameObject's position to the position of the specified
        ///     Transform.
        ///     It uses the GameObject's current position as the starting point and the position of the specified Transform as the
        ///     target.
        ///     The resulting direction vector points from the GameObject towards the position of the specified Transform.
        /// </remarks>
        public static Vector3 VectorTo(this GameObject gameObject, [NotNull] Transform transform)
        {
            if (transform == null) throw new ArgumentNullException(nameof(transform));
            return gameObject.transform.position.VectorTo(transform.position);
        }

        /// <summary>
        ///     Calculates the direction vector from the position of the GameObject to the position of the specified GameObject.
        /// </summary>
        /// <param name="gameObject">The GameObject to calculate the direction vector from.</param>
        /// <param name="other">The target GameObject whose position is the target of the direction vector.</param>
        /// <returns>
        ///     A Vector3 representing the direction vector from the position of the GameObject to the position of the specified
        ///     GameObject.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the specified GameObject is null.</exception>
        /// <remarks>
        ///     This method calculates the direction vector from the position of the GameObject to the position of the specified
        ///     GameObject.
        ///     It uses the GameObject's current position as the starting point and the position of the specified GameObject as the
        ///     target.
        ///     The resulting direction vector points from the GameObject towards the position of the specified GameObject.
        /// </remarks>
        public static Vector3 VectorTo(this GameObject gameObject, [NotNull] GameObject other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return gameObject.transform.position.VectorTo(other.transform.position);
        }

        /// <summary>
        ///     Calculates the direction vector from the specified point to the position of the GameObject.
        /// </summary>
        /// <param name="gameObject">The GameObject to calculate the direction vector to.</param>
        /// <param name="point">The source point from which the direction vector is calculated.</param>
        /// <returns>
        ///     A Vector3 representing the direction vector from the specified point to the position of the GameObject.
        /// </returns>
        /// <remarks>
        ///     This method calculates the direction vector from the specified point to the position of the GameObject.
        ///     It uses the specified point as the starting point and the GameObject's current position as the target.
        ///     The resulting direction vector points from the specified point towards the position of the GameObject.
        /// </remarks>
        public static Vector3 VectorFrom(this GameObject gameObject, Vector3 point)
        {
            return gameObject.transform.position.VectorFrom(point);
        }

        /// <summary>
        ///     Calculates the direction vector from the specified Transform to the position of the GameObject.
        /// </summary>
        /// <param name="gameObject">The GameObject to calculate the direction vector to.</param>
        /// <param name="transform">The Transform whose position is the source of the direction vector.</param>
        /// <returns>
        ///     A Vector3 representing the direction vector from the specified Transform to the position of the GameObject.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the specified Transform is null.</exception>
        /// <remarks>
        ///     This method calculates the direction vector from the specified Transform to the position of the GameObject.
        ///     It uses the Transform's position as the starting point and the GameObject's current position as the target.
        ///     The resulting direction vector points from the specified Transform towards the position of the GameObject.
        /// </remarks>
        public static Vector3 VectorFrom(this GameObject gameObject, [NotNull] Transform transform)
        {
            if (transform == null) throw new ArgumentNullException(nameof(transform));
            return gameObject.transform.position.VectorFrom(transform.position);
        }

        /// <summary>
        ///     Calculates the direction vector from the position of the specified GameObject to the position of the GameObject.
        /// </summary>
        /// <param name="gameObject">The GameObject to calculate the direction vector to.</param>
        /// <param name="other">The source GameObject whose position is the source of the direction vector.</param>
        /// <returns>
        ///     A Vector3 representing the direction vector from the position of the specified GameObject to the position of the
        ///     GameObject.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the specified GameObject is null.</exception>
        /// <remarks>
        ///     This method calculates the direction vector from the position of the specified GameObject to the position of the
        ///     GameObject.
        ///     It uses the position of the specified GameObject as the starting point and the GameObject's current position as the
        ///     target.
        ///     The resulting direction vector points from the position of the specified GameObject towards the position of the
        ///     GameObject.
        /// </remarks>
        public static Vector3 VectorFrom(this GameObject gameObject, [NotNull] GameObject other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return gameObject.transform.position.VectorFrom(other.transform.position);
        }

        /// <summary>
        ///     Calculates the direction vector from the position of the GameObject to the specified point.
        /// </summary>
        /// <param name="gameObject">The GameObject to calculate the direction vector from.</param>
        /// <param name="point">The target point to which the direction vector is calculated.</param>
        /// <returns>
        ///     A Vector3 representing the direction vector from the position of the GameObject to the specified point.
        /// </returns>
        public static Vector3 DirectionTo(this GameObject gameObject, Vector3 point)
        {
            return gameObject.transform.position.DirectionTo(point);
        }

        /// <summary>
        ///     Calculates the direction vector from the position of the GameObject to the position of the specified Transform.
        /// </summary>
        /// <param name="gameObject">The GameObject to calculate the direction vector from.</param>
        /// <param name="transform">The Transform whose position is the target of the direction vector.</param>
        /// <returns>
        ///     A Vector3 representing the direction vector from the position of the GameObject to the position of the specified
        ///     Transform.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the specified Transform is null.</exception>
        public static Vector3 DirectionTo(this GameObject gameObject, [NotNull] Transform transform)
        {
            if (transform == null) throw new ArgumentNullException(nameof(transform));
            return gameObject.transform.position.DirectionTo(transform.position);
        }

        /// <summary>
        ///     Calculates the direction vector from the position of the GameObject to the position of the specified GameObject.
        /// </summary>
        /// <param name="gameObject">The GameObject to calculate the direction vector from.</param>
        /// <param name="other">The target GameObject whose position is the target of the direction vector.</param>
        /// <returns>
        ///     A Vector3 representing the direction vector from the position of the GameObject to the position of the specified
        ///     GameObject.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the specified GameObject is null.</exception>
        public static Vector3 DirectionTo(this GameObject gameObject, [NotNull] GameObject other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return gameObject.transform.position.DirectionTo(other.transform.position);
        }

        /// <summary>
        ///     Calculates the direction vector from the specified point to the position of the GameObject.
        /// </summary>
        /// <param name="gameObject">The GameObject to calculate the direction vector to.</param>
        /// <param name="point">The source point from which the direction vector is calculated.</param>
        /// <returns>
        ///     A Vector3 representing the direction vector from the specified point to the position of the GameObject.
        /// </returns>
        public static Vector3 DirectionFrom(this GameObject gameObject, Vector3 point)
        {
            return gameObject.transform.position.DirectionFrom(point);
        }

        /// <summary>
        ///     Calculates the direction vector from the specified Transform to the position of the GameObject.
        /// </summary>
        /// <param name="gameObject">The GameObject to calculate the direction vector to.</param>
        /// <param name="transform">The Transform whose position is the source of the direction vector.</param>
        /// <returns>
        ///     A Vector3 representing the direction vector from the specified Transform to the position of the GameObject.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the specified Transform is null.</exception>
        public static Vector3 DirectionFrom(this GameObject gameObject, [NotNull] Transform transform)
        {
            if (transform == null) throw new ArgumentNullException(nameof(transform));
            return gameObject.transform.position.DirectionFrom(transform.position);
        }

        /// <summary>
        ///     Calculates the direction vector from the position of the specified GameObject to the position of the GameObject.
        /// </summary>
        /// <param name="gameObject">The GameObject to calculate the direction vector to.</param>
        /// <param name="other">The source GameObject whose position is the source of the direction vector.</param>
        /// <returns>
        ///     A Vector3 representing the direction vector from the position of the specified GameObject to the position of the
        ///     GameObject.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the specified GameObject is null.</exception>
        public static Vector3 DirectionFrom(this GameObject gameObject, [NotNull] GameObject other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return gameObject.transform.position.DirectionFrom(other.transform.position);
        }

        /// <summary>
        ///     Calculates the distance between the position of the GameObject and the specified point.
        /// </summary>
        /// <param name="gameObject">The GameObject to calculate the distance to.</param>
        /// <param name="point">The target point whose distance is calculated from the GameObject's position.</param>
        /// <returns>
        ///     The distance between the position of the GameObject and the specified point.
        /// </returns>
        public static float DistanceTo(this GameObject gameObject, Vector3 point)
        {
            return gameObject.transform.position.DistanceTo(point);
        }

        /// <summary>
        ///     Calculates the distance between the position of the GameObject and the position of the specified Transform.
        /// </summary>
        /// <param name="gameObject">The GameObject to calculate the distance to.</param>
        /// <param name="transform">The Transform whose position is the target of the distance calculation.</param>
        /// <returns>
        ///     The distance between the position of the GameObject and the position of the specified Transform.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the specified Transform is null.</exception>
        public static float DistanceTo(this GameObject gameObject, [NotNull] Transform transform)
        {
            if (transform == null) throw new ArgumentNullException(nameof(transform));
            return gameObject.transform.position.DistanceTo(transform.position);
        }

        /// <summary>
        ///     Calculates the distance between the position of the GameObject and the position of the specified GameObject.
        /// </summary>
        /// <param name="gameObject">The GameObject to calculate the distance to.</param>
        /// <param name="other">The target GameObject whose position is the target of the distance calculation.</param>
        /// <returns>
        ///     The distance between the position of the GameObject and the position of the specified GameObject.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the specified GameObject is null.</exception>
        public static float DistanceTo(this GameObject gameObject, [NotNull] GameObject other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return gameObject.transform.position.DistanceTo(other.transform.position);
        }
    }
}