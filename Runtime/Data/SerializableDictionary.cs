using System;
using System.Collections.Generic;
using UnityEngine;

namespace SODD.Data
{
    [Serializable]
    public class SerializableDictionary<TK, TV> : Dictionary<TK, TV>, ISerializationCallbackReceiver
    {
        [SerializeField] private Entry[] entries;

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            Clear();
            foreach (var entry in entries) this[entry.key] = entry.value;
        }

        [Serializable]
        internal struct Entry
        {
            public TK key;
            public TV value;

            public Entry(KeyValuePair<TK, TV> pair)
            {
                key = pair.Key;
                value = pair.Value;
            }
        }
    }
}