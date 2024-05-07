using System;
using JetBrains.Annotations;
using UnityEngine;

namespace SODD.Core
{
    /// <summary>
    ///     Extends <see cref="Transform" /> type providing utility methods.
    /// </summary>
    public static class TransformExtensions
    {
        /// <summary>
        ///     Calculates the vector from the current transform's position to the specified point.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="point">The target point.</param>
        /// <returns>The vector from the current transform's position to the target point.</returns>
        public static Vector3 VectorTo(this Transform transform, Vector3 point)
        {
            return transform.position.VectorTo(point);
        }

        /// <summary>
        ///     Calculates the vector from the current transform's position to another transform's position.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="other">The other transform.</param>
        /// <returns>The vector from the current transform's position to the other transform's position.</returns>
        public static Vector3 VectorTo(this Transform transform, [NotNull] Transform other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return transform.position.VectorTo(other.position);
        }

        /// <summary>
        ///     Calculates the vector from the current transform's position to a GameObject's position.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="gameObject">The GameObject.</param>
        /// <returns>The vector from the current transform's position to the GameObject's position.</returns>
        public static Vector3 VectorTo(this Transform transform, [NotNull] GameObject gameObject)
        {
            if (gameObject == null) throw new ArgumentNullException(nameof(gameObject));
            return transform.position.VectorTo(gameObject.transform.position);
        }

        /// <summary>
        ///     Calculates the vector from the specified point to the current transform's position.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="point">The starting point.</param>
        /// <returns>The vector from the specified point to the current transform's position.</returns>
        public static Vector3 VectorFrom(this Transform transform, Vector3 point)
        {
            return transform.position.VectorFrom(point);
        }

        /// <summary>
        ///     Calculates the vector from the specified transform's position to the current transform's position.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="other">The other transform.</param>
        /// <returns>The vector from the specified transform's position to the current transform's position.</returns>
        public static Vector3 VectorFrom(this Transform transform, [NotNull] Transform other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return transform.position.VectorFrom(other.position);
        }

        /// <summary>
        ///     Calculates the vector from the specified GameObject's position to the current transform's position.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="gameObject">The GameObject.</param>
        /// <returns>The vector from the specified GameObject's position to the current transform's position.</returns>
        public static Vector3 VectorFrom(this Transform transform, [NotNull] GameObject gameObject)
        {
            if (gameObject == null) throw new ArgumentNullException(nameof(gameObject));
            return transform.position.VectorFrom(gameObject.transform.position);
        }

        /// <summary>
        ///     Calculates the direction vector from the current transform's position to the specified point.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="point">The target point.</param>
        /// <returns>The direction vector from the current transform's position to the target point.</returns>
        public static Vector3 DirectionTo(this Transform transform, Vector3 point)
        {
            return transform.position.DirectionTo(point);
        }

        /// <summary>
        ///     Calculates the direction vector from the current transform's position to another transform's position.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="other">The other transform.</param>
        /// <returns>The direction vector from the current transform's position to the other transform's position.</returns>
        public static Vector3 DirectionTo(this Transform transform, [NotNull] Transform other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return transform.position.DirectionTo(other.position);
        }

        /// <summary>
        ///     Calculates the direction vector from the current transform's position to a GameObject's position.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="gameObject">The GameObject.</param>
        /// <returns>The direction vector from the current transform's position to the GameObject's position.</returns>
        public static Vector3 DirectionTo(this Transform transform, [NotNull] GameObject gameObject)
        {
            if (gameObject == null) throw new ArgumentNullException(nameof(gameObject));
            return transform.position.DirectionTo(gameObject.transform.position);
        }

        /// <summary>
        ///     Calculates the direction vector from the specified point to the current transform's position.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="point">The starting point.</param>
        /// <returns>The direction vector from the specified point to the current transform's position.</returns>
        public static Vector3 DirectionFrom(this Transform transform, Vector3 point)
        {
            return transform.position.DirectionFrom(point);
        }

        /// <summary>
        ///     Calculates the direction vector from the specified transform's position to the current transform's position.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="other">The other transform.</param>
        /// <returns>The direction vector from the specified transform's position to the current transform's position.</returns>
        public static Vector3 DirectionFrom(this Transform transform, [NotNull] Transform other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return transform.position.DirectionFrom(other.position);
        }

        /// <summary>
        ///     Calculates the direction vector from the specified GameObject's position to the current transform's position.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="gameObject">The GameObject.</param>
        /// <returns>The direction vector from the specified GameObject's position to the current transform's position.</returns>
        public static Vector3 DirectionFrom(this Transform transform, [NotNull] GameObject gameObject)
        {
            if (gameObject == null) throw new ArgumentNullException(nameof(gameObject));
            return transform.position.DirectionFrom(gameObject.transform.position);
        }

        /// <summary>
        ///     Calculates the distance between the current transform's position and the specified point.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="point">The target point.</param>
        /// <returns>The distance between the current transform's position and the target point.</returns>
        public static float DistanceTo(this Transform transform, Vector3 point)
        {
            return transform.position.DistanceTo(point);
        }

        /// <summary>
        ///     Calculates the distance between the current transform's position and another transform's position.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="other">The other transform.</param>
        /// <returns>The distance between the current transform's position and the other transform's position.</returns>
        public static float DistanceTo(this Transform transform, [NotNull] Transform other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return transform.position.DistanceTo(other.position);
        }

        /// <summary>
        ///     Calculates the distance between the current transform's position and a GameObject's position.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="gameObject">The GameObject.</param>
        /// <returns>The distance between the current transform's position and the GameObject's position.</returns>
        public static float DistanceTo(this Transform transform, [NotNull] GameObject gameObject)
        {
            if (gameObject == null) throw new ArgumentNullException(nameof(gameObject));
            return transform.position.DistanceTo(gameObject.transform.position);
        }
    }
}