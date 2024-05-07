namespace SODD.Core
{
    /// <summary>
    ///     Extends primitive types providing utility methods.
    /// </summary>
    public static class PrimitiveTypeExtensions
    {
        /// <summary>
        ///     Converts a boolean value to an integer representation.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <returns>
        ///     The integer representation of the boolean value:
        ///     1 if the input value is true, and 0 if the input value is false.
        /// </returns>
        /// <remarks>
        ///     This method converts a boolean value to its corresponding integer representation:
        ///     1 for true and 0 for false. It is a convenient way to obtain an integer value
        ///     when dealing with boolean conditions in certain scenarios.
        /// </remarks>
        public static int ToInt(this bool value)
        {
            return value ? 1 : 0;
        }

        /// <summary>
        ///     Converts an integer value to a boolean representation.
        /// </summary>
        /// <param name="value">The integer value to convert.</param>
        /// <returns>
        ///     True if the input integer value is non-zero; otherwise, false if the input integer value is 0.
        /// </returns>
        /// <remarks>
        ///     This method converts an integer value to its corresponding boolean representation:
        ///     true if the input integer value is non-zero, and false if the input integer value is 0.
        ///     It is a convenient way to interpret integer values as boolean conditions in certain scenarios.
        /// </remarks>
        public static bool ToBool(this int value)
        {
            return value != 0;
        }
    }
}