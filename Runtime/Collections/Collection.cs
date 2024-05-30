using System.Collections;
using System.Collections.Generic;
using SODD.Attributes;
using SODD.Events;
using UnityEngine;
using Random = System.Random;
#if UNITY_EDITOR
using Logger = SODD.Core.Logger;
#endif

namespace SODD.Collections
{
    /// <summary>
    ///     Represents an abstract collection of items of type T.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <remarks>
    ///     <para>
    ///         This abstract class provides the foundation for creating scriptable collection implementations.
    ///         It enables the encapsulation and serialization a list of items, allowing for easy manipulation and reference
    ///         within the Unity Editor
    ///         and across different game components. Such collections are beneficial for managing groups of related items,
    ///         such as inventory items, enemies, or waypoints, in a centralized and organized manner.
    ///     </para>
    ///     <para>
    ///         The collection supports adding and removing items and provides events for tracking these modifications.
    ///         This functionality facilitates reactive programming patterns, where changes to the collection can trigger
    ///         corresponding actions or updates within the game.
    ///     </para>
    ///     <para>
    ///         To create a custom collection, inherit from this class and specify the item type <typeparamref name="T" />,
    ///         which can be any type supported by Unity (e.g., GameObject, int, string).
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Example of a GameObject collection implementation:
    ///     <code>
    ///         [CreateAssetMenu(menuName = "My Collections/GameObject Collection", fileName = nameof(GameObjectCollection)]    
    ///         public class GameObjectCollection : Collection&lt;GameObject&gt; {}
    ///     </code>
    /// </example>
    public abstract class Collection<T> : ScriptableObject, IList<T>
    {
        [SerializeField] 
        private List<T> items = new();
#if UNITY_EDITOR
        [Tooltip("Enable this setting to log the changes in this collection in the console.")] [SerializeField]
        private bool debug;
#endif

        /// <summary>
        ///     Event triggered when an item is added to the collection.
        /// </summary>
        public GenericEvent<T> OnItemAdded = new();

        /// <summary>
        ///     Event triggered when an item is removed from the collection.
        /// </summary>
        public GenericEvent<T> OnItemRemoved = new();

        /// <summary>
        ///     Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator for the collection of items.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        /// <summary>
        ///     Returns an enumerator that iterates through the collection (non-generic).
        /// </summary>
        /// <returns>An enumerator for the collection of items.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Adds an item to the collection, triggering the OnItemAdded event.
        /// </summary>
        /// <param name="item">The item to add to the collection.</param>
        public void Add(T item)
        {
            items.Add(item);
            HandleItemAdded(item);
        }

        /// <summary>
        ///     Removes all items from the collection, triggering the OnItemRemoved event for each item.
        /// </summary>
        public void Clear()
        {
            items.ForEach(HandleItemRemoved);
            items.Clear();
        }

        /// <summary>
        ///     Determines whether the collection contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the collection.</param>
        /// <returns>true if item is found in the collection; otherwise, false.</returns>
        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        /// <summary>
        ///     Copies the elements of the collection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from the collection.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        ///     Removes the first occurrence of a specific object from the collection, triggering the OnItemRemoved event.
        /// </summary>
        /// <param name="item">The item to remove from the collection.</param>
        /// <returns>true if item was successfully removed from the collection; otherwise, false.</returns>
        public bool Remove(T item)
        {
            if (!items.Remove(item)) return false;
            HandleItemRemoved(item);
            return true;
        }

        /// <summary>
        ///     Gets the number of elements contained in the collection.
        /// </summary>
        public int Count => items.Count;

        /// <summary>
        ///     Gets a value indicating whether the collection is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        private void HandleItemAdded(T item)
        {
            OnItemAdded?.Invoke(item);
#if UNITY_EDITOR
            if (debug) Logger.LogAsset(this, $"Item added: {item}");
#endif
        }

        private void HandleItemRemoved(T item)
        {
            OnItemRemoved?.Invoke(item);
#if UNITY_EDITOR
            if (debug) Logger.LogAsset(this, $"Item removed: {item}");
#endif
        }

        /// <summary>
        ///     Retrieves the index of a specific item in the collection.
        /// </summary>
        /// <param name="item">The item to locate in the collection.</param>
        /// <returns>The index of the item if found in the collection; otherwise, -1.</returns>
        public int IndexOf(T item)
        {
            return items.IndexOf(item);
        }

        /// <summary>
        ///     Inserts an item at the specified index in the collection.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The item to insert.</param>
        public void Insert(int index, T item)
        {
            items.Insert(index, item);
            HandleItemAdded(item);
        }

        /// <summary>
        ///     Removes the item at the specified index from the collection.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        public void RemoveAt(int index)
        {
            var item = items[index];
            items.RemoveAt(index);
            HandleItemRemoved(item);
        }

        /// <summary>
        ///     Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public T this[int index]
        {
            get => items[index];
            set => items[index] = value;
        }

        /// <summary>
        ///     Returns a random item from the collection.
        /// </summary>
        /// <returns>A randomly selected item from the collection.</returns>
        public T GetRandom()
        {
            return items[new Random().Next(0, items.Count)];
        }
    }
}