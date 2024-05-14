namespace SODD.Repositories
{
    /// <summary>
    ///     Defines a generic repository interface for managing persistent data.
    /// </summary>
    /// <typeparam name="T">The type of data the repository will manage.</typeparam>
    /// <remarks>
    ///     This interface provides a basic framework for implementing CRUD (Create, Read, Update, Delete) operations on data
    ///     of type <typeparamref name="T" />.
    ///     Implementations of this interface should handle specifics of data storage, retrieval, and deletion.
    /// </remarks>
    public interface IRepository<T>
    {
        /// <summary>
        ///     Saves the specified entity of type <typeparamref name="T" /> to the repository.
        /// </summary>
        /// <param name="t">The entity to save.</param>
        void Save(T t);

        /// <summary>
        ///     Loads the entity of type <typeparamref name="T" /> from the repository.
        /// </summary>
        /// <returns>The loaded entity of type <typeparamref name="T" />.</returns>
        T Load();

        /// <summary>
        ///     Deletes the entity of type <typeparamref name="T" /> from the repository.
        /// </summary>
        void Delete();
    }
}