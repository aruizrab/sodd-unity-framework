using System;

namespace SODD.Core
{
    /// <summary>
    ///     Represents a type that signifies the absence of any value.
    /// </summary>
    /// <remarks>
    ///     The <see cref="Void" /> type is used as a placeholder type parameter in events where no other data is needed.
    ///     This allows for the use of generic event handling mechanisms without needing to specify a meaningful type.
    ///     It is primarily used in the <see cref="VoidEvent" /> to represent an event that is triggered without any
    ///     accompanying data.
    /// </remarks>
    [Serializable]
    public struct Void
    {
        /// <summary>
        ///     Provides a singleton instance of the Void type, used to represent an empty value.
        /// </summary>
        public static readonly Void Instance = new();
    }
}