using UnityEngine;

namespace SODD.Core
{
    /// <summary>
    ///     Extends <see cref="Vector2" /> type providing utility methods.
    /// </summary>
    public static class Vector2Extensions
    {
        /// <summary>
        ///     Calculates the vector from the current Vector2 to the specified point.
        /// </summary>
        /// <param name="vector2">The current Vector2.</param>
        /// <param name="point">The target point.</param>
        /// <returns>The vector from the current Vector2 to the target point.</returns>
        public static Vector2 VectorTo(this Vector2 vector2, Vector2 point)
        {
            return point - vector2;
        }

        /// <summary>
        ///     Calculates the direction vector from the current Vector2 to the specified point.
        /// </summary>
        /// <param name="vector2">The current Vector2.</param>
        /// <param name="point">The target point.</param>
        /// <returns>The direction vector from the current Vector2 to the target point.</returns>
        public static Vector2 DirectionTo(this Vector2 vector2, Vector2 point)
        {
            return (point - vector2).normalized;
        }

        /// <summary>
        ///     Calculates the vector from the specified point to the current Vector2.
        /// </summary>
        /// <param name="vector2">The current Vector2.</param>
        /// <param name="point">The starting point.</param>
        /// <returns>The vector from the specified point to the current Vector2.</returns>
        public static Vector2 VectorFrom(this Vector2 vector2, Vector2 point)
        {
            return vector2 - point;
        }

        /// <summary>
        ///     Calculates the direction vector from the specified point to the current Vector2.
        /// </summary>
        /// <param name="vector2">The current Vector2.</param>
        /// <param name="point">The starting point.</param>
        /// <returns>The direction vector from the specified point to the current Vector2.</returns>
        public static Vector2 DirectionFrom(this Vector2 vector2, Vector2 point)
        {
            return (vector2 - point).normalized;
        }

        /// <summary>
        ///     Calculates the distance between the current Vector2 and the specified point.
        /// </summary>
        /// <param name="vector2">The current Vector2.</param>
        /// <param name="point">The target point.</param>
        /// <returns>The distance between the current Vector2 and the target point.</returns>
        public static float DistanceTo(this Vector2 vector2, Vector2 point)
        {
            return (point - vector2).magnitude;
        }

        /// <summary>
        ///     Rotates the current Vector2 by the specified angle around the specified axis.
        /// </summary>
        /// <param name="vector">The current Vector2.</param>
        /// <param name="angle">The angle to rotate by.</param>
        /// <param name="axis">The axis to rotate around.</param>
        /// <returns>The rotated Vector2.</returns>
        public static Vector2 Rotate(this Vector2 vector, float angle, Vector2 axis)
        {
            return Quaternion.AngleAxis(angle, axis) * vector;
        }
    }
}