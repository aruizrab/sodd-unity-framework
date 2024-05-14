using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using JetBrains.Annotations;
using UnityEngine;

namespace SODD.Repositories
{
    /// <summary>
    ///     Provides a concrete implementation of <see cref="FileRepository{T}" /> that manages data through binary
    ///     serialization.
    /// </summary>
    /// <typeparam name="T">The type of data managed by the repository.</typeparam>
    /// <remarks>
    ///     This class implements the saving, loading, and deleting of data using the <see cref="BinaryFormatter" />,
    ///     which serializes and deserializes an object, or an entire graph of connected objects, in binary format.
    ///     It is suitable for storing data such as game states, configurations, or user data in a compact, binary format
    ///     that is not human-readable, enhancing both security and storage efficiency.
    /// </remarks>
    public class BinaryFileRepository<T> : FileRepository<T>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BinaryFileRepository{T}" /> class.
        /// </summary>
        public BinaryFileRepository()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BinaryFileRepository{T}" /> class with the specified filename.
        /// </summary>
        /// <param name="filename">The filename to use for storing the binary data. Cannot be null.</param>
        public BinaryFileRepository([NotNull] string filename) : base(filename)
        {
        }

        /// <summary>
        ///     Saves the specified entity to a binary file.
        /// </summary>
        /// <param name="t">The entity to save. The entity must be serializable.</param>
        /// <remarks>
        ///     This method serializes the object of type <typeparamref name="T" /> using <see cref="BinaryFormatter" />
        ///     and writes it to a file specified by <see cref="FileRepository{T}.Filename" />.
        ///     The data path used is <see cref="Application.persistentDataPath" />.
        /// </remarks>
        public override void Save(T t)
        {
            var bf = new BinaryFormatter();
            var file = File.Create($"{Application.persistentDataPath}/{filename}.bin");
            bf.Serialize(file, t);
            file.Close();
        }

        /// <summary>
        ///     Loads the entity from a binary file.
        /// </summary>
        /// <returns>The loaded entity of type <typeparamref name="T" />.</returns>
        /// <remarks>
        ///     This method deserializes the data from a binary file specified by <see cref="FileRepository{T}.Filename" />
        ///     into an object of type <typeparamref name="T" />.
        /// </remarks>
        public override T Load()
        {
            var bf = new BinaryFormatter();
            var file = File.Open($"{Application.persistentDataPath}/{filename}.bin", FileMode.Open);
            var data = (T)bf.Deserialize(file);
            file.Close();
            return data;
        }

        /// <summary>
        ///     Deletes the binary file where the data is stored.
        /// </summary>
        /// <remarks>
        ///     This method deletes the file specified by <see cref="FileRepository{T}.Filename" /> from
        ///     <see cref="Application.persistentDataPath" />.
        /// </remarks>
        public override void Delete()
        {
            File.Delete($"{Application.persistentDataPath}/{filename}.bin");
        }
    }
}