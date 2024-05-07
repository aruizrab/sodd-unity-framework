using UnityEngine;

namespace SODD.Core
{
    /// <summary>
    ///     Extends <see cref="Vector3" /> type providing utility methods.
    /// </summary>
    public static class Vector3Extensions
    {
        /// <summary>
        ///     Calculates the vector from the current Vector3 to the specified point.
        /// </summary>
        /// <param name="vector3">The current Vector3.</param>
        /// <param name="point">The target point.</param>
        /// <returns>The vector from the current Vector3 to the target point.</returns>
        public static Vector3 VectorTo(this Vector3 vector3, Vector3 point)
        {
            return point - vector3;
        }

        /// <summary>
        ///     Calculates the direction vector from the current Vector3 to the specified point.
        /// </summary>
        /// <param name="vector3">The current Vector3.</param>
        /// <param name="point">The target point.</param>
        /// <returns>The direction vector from the current Vector3 to the target point.</returns>
        public static Vector3 DirectionTo(this Vector3 vector3, Vector3 point)
        {
            return (point - vector3).normalized;
        }

        /// <summary>
        ///     Calculates the vector from the specified point to the current Vector3.
        /// </summary>
        /// <param name="vector3">The current Vector3.</param>
        /// <param name="point">The starting point.</param>
        /// <returns>The vector from the specified point to the current Vector3.</returns>
        public static Vector3 VectorFrom(this Vector3 vector3, Vector3 point)
        {
            return vector3 - point;
        }

        /// <summary>
        ///     Calculates the direction vector from the specified point to the current Vector3.
        /// </summary>
        /// <param name="vector3">The current Vector3.</param>
        /// <param name="point">The starting point.</param>
        /// <returns>The direction vector from the specified point to the current Vector3.</returns>
        public static Vector3 DirectionFrom(this Vector3 vector3, Vector3 point)
        {
            return (vector3 - point).normalized;
        }

        /// <summary>
        ///     Calculates the distance between the current Vector3 and the specified point.
        /// </summary>
        /// <param name="vector3">The current Vector3.</param>
        /// <param name="point">The target point.</param>
        /// <returns>The distance between the current Vector3 and the target point.</returns>
        public static float DistanceTo(this Vector3 vector3, Vector3 point)
        {
            return (point - vector3).magnitude;
        }

        /// <summary>
        ///     Rotates the current Vector3 by the specified angle around the specified axis.
        /// </summary>
        /// <param name="vector">The current Vector3.</param>
        /// <param name="angle">The angle to rotate by.</param>
        /// <param name="axis">The axis to rotate around.</param>
        /// <returns>The rotated Vector3.</returns>
        public static Vector3 Rotate(this Vector3 vector, float angle, Vector3 axis)
        {
            return Quaternion.AngleAxis(angle, axis) * vector;
        }
    }
}