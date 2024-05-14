using System.IO;
using JetBrains.Annotations;
using UnityEngine;

namespace SODD.Repositories
{
    /// <summary>
    ///     Provides a concrete implementation of <see cref="FileRepository{T}" /> that manages data through JSON
    ///     serialization.
    /// </summary>
    /// <typeparam name="T">The type of data managed by the repository.</typeparam>
    /// <remarks>
    ///     This class implements the saving, loading, and deleting of data using JSON serialization,
    ///     leveraging <see cref="JsonUtility" /> for serialization and deserialization. It is ideal for storing data such as
    ///     game settings, player progress, or other configuration data in a human-readable format, making it easier to edit
    ///     manually if necessary.
    /// </remarks>
    public class JsonFileRepository<T> : FileRepository<T>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonFileRepository{T}" /> class.
        /// </summary>
        public JsonFileRepository()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonFileRepository{T}" /> class with the specified filename.
        /// </summary>
        /// <param name="filename">The filename to use for storing the JSON data. Cannot be null.</param>
        public JsonFileRepository([NotNull] string filename) : base(filename)
        {
        }

        /// <summary>
        ///     Saves the specified entity to a JSON file.
        /// </summary>
        /// <param name="t">The entity to save.</param>
        /// <remarks>
        ///     This method serializes the object of type <typeparamref name="T" /> using <see cref="JsonUtility" />
        ///     and writes it to a file specified by <see cref="FileRepository{T}.Filename" />.
        ///     The data path used is <see cref="Application.persistentDataPath" />.
        /// </remarks>
        public override void Save(T t)
        {
            var path = $"{Application.persistentDataPath}/{filename}.json";
            var json = JsonUtility.ToJson(t);
            
            File.WriteAllText(path, json);
        }

        /// <summary>
        ///     Loads the entity from a JSON file.
        /// </summary>
        /// <returns>The loaded entity of type <typeparamref name="T" />.</returns>
        /// <remarks>
        ///     This method deserializes the data from a JSON file specified by <see cref="FileRepository{T}.Filename" />
        ///     into an object of type <typeparamref name="T" /> using <see cref="JsonUtility" />.
        /// </remarks>
        public override T Load()
        {
            var path = $"{Application.persistentDataPath}/{filename}.json";
            var json = File.ReadAllText(path);
            
            return JsonUtility.FromJson<T>(json);
        }

        /// <summary>
        ///     Deletes the JSON file where the data is stored.
        /// </summary>
        /// <remarks>
        ///     This method deletes the file specified by <see cref="FileRepository{T}.Filename" /> from
        ///     <see cref="Application.persistentDataPath" />.
        /// </remarks>
        public override void Delete()
        {
            File.Delete($"{Application.persistentDataPath}/{filename}.json");
        }
    }
}