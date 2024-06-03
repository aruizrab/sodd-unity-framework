using System;
using System.Collections.Generic;
using UnityEngine;

namespace SODD.Data
{
    /// <summary>
    ///     A dictionary that supports Unity serialization.
    /// </summary>
    /// <typeparam name="TK">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TV">The type of the values in the dictionary.</typeparam>
    /// <remarks>
    ///     The <see cref="SerializableDictionary{TK, TV}" /> class extends <see cref="Dictionary{TK,TV}" /> and implements
    ///     <see cref="ISerializationCallbackReceiver" /> to support Unity's serialization system. It allows dictionaries to be
    ///     serialized and deserialized within Unity, making them usable in the Inspector.
    /// </remarks>
    /// <example>
    ///     Example usage of the <see cref="SerializableDictionary{TK, TV}" /> class:
    ///     <code>
    /// [Serializable]
    /// public class MySerializableDictionary : SerializableDictionary&lt;string, int&gt; {}
    /// 
    /// public class MyComponent : MonoBehaviour
    /// {
    ///     [SerializeField]
    ///     private MySerializableDictionary myDictionary;
    /// }
    /// </code>
    /// </example>
    [Serializable]
    public class SerializableDictionary<TK, TV> : Dictionary<TK, TV>, ISerializationCallbackReceiver
    {
        /// <summary>
        ///     Entries in the dictionary to be serialized.
        /// </summary>
        [SerializeField] private Entry[] entries;

        /// <summary>
        ///     Invoked before the dictionary is serialized.
        /// </summary>
        public void OnBeforeSerialize()
        {
            // Custom logic before serialization can be added here.
        }

        /// <summary>
        ///     Invoked after the dictionary is deserialized.
        /// </summary>
        public void OnAfterDeserialize()
        {
            Clear();
            foreach (var entry in entries) this[entry.key] = entry.value;
        }

        /// <summary>
        ///     Represents a serializable key-value pair entry.
        /// </summary>
        [Serializable]
        internal struct Entry
        {
            public TK key;
            public TV value;

            /// <summary>
            ///     Initializes a new instance of the <see cref="Entry" /> struct with the specified key-value pair.
            /// </summary>
            /// <param name="pair">The key-value pair to initialize the entry with.</param>
            public Entry(KeyValuePair<TK, TV> pair)
            {
                key = pair.Key;
                value = pair.Value;
            }
        }
    }
}