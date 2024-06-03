using System;

namespace SODD.Data
{
    /// <summary>
    ///     Represents a range of comparable values.
    /// </summary>
    /// <typeparam name="T">The type of the values, which must implement <see cref="IComparable{T}" />.</typeparam>
    /// <remarks>
    ///     The <see cref="Range{T}" /> struct is used to define a range with minimum and maximum bounds. It provides
    ///     functionality
    ///     to check if a given value is within this range. This struct can be used with any type that implements
    ///     <see cref="IComparable{T}" />.
    /// </remarks>
    /// <example>
    ///     Example usage of the <see cref="Range{T}" /> struct:
    ///     <code>
    /// Range&lt;int&gt; intRange = new Range&lt;int&gt;(0, 10);
    /// bool isInRange = intRange.IsInRange(5); // Returns true
    /// </code>
    /// </example>
    [Serializable]
    public struct Range<T> where T : IComparable<T>
    {
        /// <summary>
        ///     The minimum value of the range.
        /// </summary>
        public T min;

        /// <summary>
        ///     The maximum value of the range.
        /// </summary>
        public T max;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Range{T}" /> struct with specified minimum and maximum values.
        /// </summary>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        public Range(T min, T max)
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        ///     Determines whether a specified value is within the range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns><c>true</c> if the value is within the range; otherwise, <c>false</c>.</returns>
        public bool IsInRange(T value)
        {
            return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
        }
    }
}