namespace SODD.Core
{
    /// <summary>
    /// Specifies the scope of search for components in a <see cref="GameObject"/>.
    /// </summary>
    public enum Scope
    {
        /// <summary>
        /// Search for the component only on the provided GameObject.
        /// </summary>
        GameObject,

        /// <summary>
        /// Search for the component on all children of the provided GameObject.
        /// </summary>
        Children,

        /// <summary>
        /// Search for the component on the parent of the provided GameObject.
        /// </summary>
        Parents,

        /// <summary>
        /// Search for the component on the parent and all children of the provided GameObject.
        /// </summary>
        ParentsAndChildren
    }
}