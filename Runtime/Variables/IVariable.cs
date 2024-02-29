namespace SODD.Variables
{
    /// <summary>
    ///     Represents a generic variable interface.
    /// </summary>
    /// <remarks>
    ///     This interface defines a generic variable with a non-specific type.
    ///     It's intended for use in scenarios where the type of the variable isn't known
    ///     at compile-time or needs to be treated in a type-agnostic manner.
    /// </remarks>
    public interface IVariable
    {
        /// <summary>
        ///     Gets or sets the value of the variable.
        /// </summary>
        /// <value>
        ///     The value of the variable, stored as an object.
        /// </value>
        object Value { get; set; }
    }

    /// <summary>
    ///     Represents a generic variable interface with a specific type.
    /// </summary>
    /// <typeparam name="T">The type of the variable's value.</typeparam>
    /// <remarks>
    ///     This interface defines a generic variable with a specific type, allowing for
    ///     the creation of type-safe variables. It's used to encapsulate data that can be
    ///     exposed and manipulated within the Unity Editor and through scripts.
    /// </remarks>
    public interface IVariable<T>
    {
        /// <summary>
        ///     Gets or sets the value of the variable.
        /// </summary>
        /// <value>
        ///     The value of the variable, of type T.
        /// </value>
        T Value { get; set; }
    }
}