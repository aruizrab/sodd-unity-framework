using System;

namespace SODD.Core
{
    /// <summary>
    ///     Provides extension methods for the <see cref="Comparison" /> enum.
    /// </summary>
    public static class ComparisonExtensions
    {
        /// <summary>
        ///     Evaluates the comparison between two objects based on the specified <see cref="Comparison" /> type.
        /// </summary>
        /// <param name="comparison">The type of comparison to perform.</param>
        /// <param name="value1">The first object to compare.</param>
        /// <param name="value2">The second object to compare.</param>
        /// <returns>
        ///     A boolean value indicating the result of the comparison.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the objects are not comparable or the comparison type is not applicable.
        /// </exception>
        /// <example>
        ///     This example shows how to use the Evaluate method:
        ///     <code>
        /// Comparison comparisonType = Comparison.LessThan;
        /// int value1 = 5;
        /// int value2 = 10;
        /// bool result = comparisonType.Evaluate(value1, value2);
        /// // result will be true because 5 is less than 10
        /// </code>
        /// </example>
        public static bool Evaluate(this Comparison comparison, object value1, object value2)
        {
            switch (comparison)
            {
                case Comparison.Equals:
                    return Equals(value1, value2);
                case Comparison.NotEquals:
                    return !Equals(value1, value2);
            }

            var message = $"{value1.GetType().Name} cannot be compared to {value2.GetType().Name} by {comparison}.";
            var comparable1 = value1 as IComparable ?? throw new ArgumentException(message);
            var comparable2 = value2 as IComparable ?? throw new ArgumentException(message);

            switch (comparison)
            {
                case Comparison.BiggerThan:
                    return comparable1.CompareTo(comparable2) < 0;
                case Comparison.BiggerEqualsThan:
                    return comparable1.CompareTo(comparable2) <= 0;
                case Comparison.LessThan:
                    return comparable1.CompareTo(comparable2) > 0;
                case Comparison.LessEqualsThan:
                    return comparable1.CompareTo(comparable2) >= 0;
            }

            return false;
        }
    }
}