using System;
using System.Collections.Generic;
using System.Linq;
using SODD.Core;
using SODD.Data;
using SODD.Variables;
using UnityEngine;
using JsonUtility = UnityEngine.JsonUtility;
using Logger = SODD.Core.Logger;
using Object = UnityEngine.Object;

namespace SODD.Repositories
{
    /// <summary>
    ///     Manages a repository of variables, allowing for their persistent storage and retrieval using binary serialization.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This ScriptableObject serves as a repository for various game variables, such as settings or player data,
    ///         and leverages binary serialization for efficient, non-human-readable storage. The repository can be configured
    ///         to automatically load variables when enabled and save them when disabled.
    ///     </para>
    ///     <para>
    ///         A custom editor script adds functionality to log variable data when saving or loading, and provides buttons
    ///         for manual save and load operations, aiding in testing and debugging.
    ///     </para>
    ///     <para>
    ///         The repository works with variables that extend <see cref="PersistentScriptableObject" />, which includes a
    ///         toggle
    ///         to indicate whether the variable should be persisted. This toggle allows for automatic management of variables
    ///         in the repository, simplifying the process of maintaining persistent state across game sessions.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Repositories.VariableRepository, fileName = nameof(VariableRepository))]
    public class VariableRepository : PassiveScriptableObject
    {
        /// <summary>
        ///     The filename used for storing the variables.
        /// </summary>
        [SerializeField] 
        [Tooltip("The filename used for storing the variables.")]
        private string filename = "variables";

        /// <summary>
        ///     Indicates whether to load variables when the repository is enabled.
        /// </summary>
        [SerializeField] 
        [Tooltip("Enable to automatically load variables when the repository is enabled.")]
        private bool loadOnEnable;

        /// <summary>
        ///     Indicates whether to save variables when the repository is disabled.
        /// </summary>
        [Tooltip("Enable to automatically save variables when the repository is disabled.")]
        [SerializeField] 
        private bool saveOnDisable;
#if UNITY_EDITOR
        /// <summary>
        ///     Enable this setting to log in the console whenever the repository saves or loads variable data.
        /// </summary>
        [SerializeField]
        [Tooltip("Enable this setting to log in the console whenever the repository saves or loads variable data.")]
        public bool debug;
#endif
        /// <summary>
        ///     The list of variables to be managed by the repository.
        /// </summary>
        [SerializeField] private List<Object> variables;

        private void OnEnable()
        {
            if (loadOnEnable) Load();
        }

        private void OnDisable()
        {
            if (saveOnDisable) Save();
        }

        /// <summary>
        ///     Saves the current state of variables to a binary file.
        /// </summary>
        public void Save()
        {
            var list = variables.OfType<IVariable>().ToList();
            var repository = new BinaryFileRepository<VariableStore>(filename);
            var data = new VariableStore();

            data.Store(list);
            repository.Save(data);
#if UNITY_EDITOR
            if (!debug) return;
            if (list.IsEmpty())
            {
                Logger.LogAsset(this, "Variable list is empty, no data will be saved.");
                return;
            }
            Logger.LogAsset(this,
                $"{list.Count} variable{(list.Count > 1 ? "s" : "")} ha{(list.Count > 1 ? "ve" : "s")} been saved." + Environment.NewLine +
                $"Destination file: {Application.persistentDataPath}/{filename}.bin" + Environment.NewLine +
                "Data: [" + Environment.NewLine +
                string.Join("," + Environment.NewLine, list.Select(item => JsonUtility.ToJson(item, true))) + "]");
#endif
        }

        /// <summary>
        ///     Loads the state of variables from a binary file.
        /// </summary>
        public void Load()
        {
            var repository = new BinaryFileRepository<VariableStore>(filename);

            if (!repository.Exists())
            {
#if UNITY_EDITOR
                if (debug)
                    Logger.LogAsset(this,
                        "Variable data file not found, no data will be loaded.\n" +
                        $"Source file: {Application.persistentDataPath}/{filename}.bin");
#endif
                return;
            }

            var list = variables.OfType<IVariable>().ToList();
            var data = repository.Load();

            data.Restore(list);
#if UNITY_EDITOR
            if (!debug) return;
            if (list.IsEmpty())
            {
                Logger.LogAsset(this, "Variable list is empty, no data will be loaded.");
                return;
            }
            Logger.LogAsset(this,
                $"{list.Count} variable{(list.Count > 1 ? "s" : "")} ha{(list.Count > 1 ? "ve" : "s")} been loaded." + Environment.NewLine +
                $"Destination file: {Application.persistentDataPath}/{filename}.bin" + Environment.NewLine +
                "Data: [" + Environment.NewLine +
                string.Join("," + Environment.NewLine, list.Select(item => JsonUtility.ToJson(item, true))) + "]");
#endif
        }

        /// <summary>
        ///     Deletes the binary file where the variables are stored.
        /// </summary>
        public void Delete()
        {
            var repository = new BinaryFileRepository<VariableStore>(filename);
            repository.Delete();
#if UNITY_EDITOR
            if (!debug) return;
            Logger.LogAsset(this,
                "Variable data file has been deleted.\n" +
                $"Deleted file: {Application.persistentDataPath}/{filename}.bin");
#endif
        }
        
#if UNITY_EDITOR
        [Serializable]
        internal class VariableList
        {
            public List<IVariable> Variables;

            public VariableList(List<IVariable> variables)
            {
                Variables = variables;
            }
        }
#endif
    }
}