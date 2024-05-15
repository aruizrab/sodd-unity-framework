namespace SODD.Variables
{
    /// <summary>
    ///     Represents a generic variable interface for type-agnostic variable usage.
    /// </summary>
    /// <remarks>
    ///     This interface allows for handling variables whose type might not be known at compile time or
    ///     when it is necessary to operate on variables in a type-agnostic manner. It can be used in scenarios
    ///     where variables are managed dynamically, such as in systems that load or save settings where the
    ///     types can vary.
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
        string Id { get; }
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
        string Id { get; }
    }
}