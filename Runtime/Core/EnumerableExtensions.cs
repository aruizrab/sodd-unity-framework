using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SODD.Core
{
    /// <summary>
    ///     Extends <see cref="IEnumerable{T}" /> type providing utility methods.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Creates an infinite loop by wrapping the source IEnumerable&lt;T&gt; around itself.
        /// </summary>
        /// <typeparam name="T">The type of elements in the IEnumerable&lt;T&gt;.</typeparam>
        /// <param name="source">The IEnumerable&lt;T&gt; to wrap around.</param>
        /// <returns>
        ///     An IEnumerable&lt;T&gt; that repeatedly returns elements from the source IEnumerable&lt;T&gt; in an infinite loop.
        /// </returns>
        /// <remarks>
        ///     This method creates an infinite loop by repeatedly returning elements from the source IEnumerable&lt;T&gt;.
        ///     When the end of the source sequence is reached, it wraps around and starts again from the beginning,
        ///     effectively creating an infinite sequence.
        /// </remarks>
        [SuppressMessage("ReSharper", "IteratorNeverReturns")]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public static IEnumerable<T> WrapAround<T>(this IEnumerable<T> source)
        {
            while (true)
                foreach (var item in source)
                    yield return item;
        }

        /// <summary>
        ///     Performs the specified action on each element of the IEnumerable&lt;T&gt;.
        /// </summary>
        /// <typeparam name="T">The type of elements in the IEnumerable&lt;T&gt;.</typeparam>
        /// <param name="source">The IEnumerable&lt;T&gt; to iterate over.</param>
        /// <param name="action">The action to perform on each element of the IEnumerable&lt;T&gt;.</param>
        /// <remarks>
        ///     This method iterates over each element in the source IEnumerable&lt;T&gt;
        ///     and performs the specified action on each element using the provided delegate.
        ///     If the action is null, this method does nothing and returns immediately.
        /// </remarks>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source) action?.Invoke(item);
        }

        /// <summary>
        ///     Tries to find an element in the IEnumerable&lt;T&gt; that matches the specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the IEnumerable&lt;T&gt;.</typeparam>
        /// <param name="source">The IEnumerable&lt;T&gt; to search.</param>
        /// <param name="predicate">The predicate function used to find the element.</param>
        /// <param name="output">
        ///     When this method returns, contains the first element that matches the predicate, if found;
        ///     otherwise, the default value of type T.
        /// </param>
        /// <returns>
        ///     True if an element matching the predicate is found and stored in the <paramref name="output" /> parameter;
        ///     otherwise, false if no such element is found.
        /// </returns>
        /// <remarks>
        ///     This method searches the source IEnumerable&lt;T&gt; for an element that matches the specified predicate function.
        ///     If a matching element is found, it is stored in the <paramref name="output" /> parameter and the method returns
        ///     true.
        ///     If no matching element is found, the <paramref name="output" /> parameter is set to the default value of type T and
        ///     the method returns false.
        /// </remarks>
        public static bool TryFind<T>(this IEnumerable<T> source, Func<T, bool> predicate, out T output)
        {
            output = source.FirstOrDefault(predicate);
            return !EqualityComparer<T>.Default.Equals(output, default);
        }        
        
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }
    }
}