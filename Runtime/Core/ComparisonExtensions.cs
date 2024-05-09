using System;

namespace SODD.Core
{
    public static class ComparisonExtensions
    {
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