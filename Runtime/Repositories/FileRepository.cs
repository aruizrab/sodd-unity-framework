using JetBrains.Annotations;

namespace SODD.Repositories
{
    /// <summary>
    /// Provides a base implementation of <see cref="IRepository{T}" /> for file-based data storage.
    /// </summary>
    /// <typeparam name="T">The type of data managed by the repository.</typeparam>
    /// <remarks>
    /// This abstract class lays the foundation for creating file-based repositories that can save, load, and delete
    /// data of type <typeparamref name="T"/>. Implementations require a filename for the underlying storage mechanism.
    /// </remarks>
    public abstract class FileRepository<T> : IRepository<T>
    {
        /// <summary>
        /// The filename used for storing data.
        /// </summary>
        protected string filename;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileRepository{T}"/> class without specifying a filename.
        /// The filename must be set before performing I/O operations.
        /// </summary>
        protected FileRepository()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileRepository{T}"/> class with the specified filename.
        /// </summary>
        /// <param name="filename">The filename to use for data storage. Cannot be null.</param>
        protected FileRepository([NotNull] string filename)
        {
            this.filename = filename;
        }

        /// <summary>
        /// Gets or sets the filename used for data storage.
        /// </summary>
        public virtual string Filename
        {
            get => filename;
            set => filename = value;
        }

        /// <inheritdoc />
        public abstract void Save(T t);
        
        /// <inheritdoc />
        public abstract T Load();
        
        /// <inheritdoc />
        public abstract void Delete();

        /// <inheritdoc />
        public abstract bool Exists();
    }
}