using System.Collections.Generic;
using System.Linq;
using SODD.Data;
using SODD.Variables;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SODD.Repositories
{
    /// <summary>
    ///     Manages a repository of variables, allowing for their persistent storage and retrieval using binary serialization.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This ScriptableObject serves as a repository for various game variables, such as settings or player data,
    ///         and leverages binary serialization for efficient, non-human-readable storage.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Repositories.VariableRepository, fileName = nameof(VariableRepository))]
    public class VariableRepository : ScriptableObject
    {
        [SerializeField] private string filename;
        [SerializeField] private bool loadOnEnable;
        [SerializeField] private bool saveOnDisable;
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
        }

        /// <summary>
        ///     Loads the state of variables from a binary file.
        /// </summary>
        public void Load()
        {
            var repository = new BinaryFileRepository<VariableStore>(filename);

            if (!repository.Exists()) return;

            var list = variables.OfType<IVariable>().ToList();
            var data = repository.Load();

            data.Restore(list);
        }

        /// <summary>
        ///     Deletes the binary file where the variables are stored.
        /// </summary>
        public void Delete()
        {
            new BinaryFileRepository<VariableStore>(filename).Delete();
        }
    }
}