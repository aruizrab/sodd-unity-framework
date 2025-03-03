using System;

namespace SODD.AI
{
    /// <summary>
    /// Specifies the strategies for collision detection.
    /// </summary>
    [Flags]
    public enum CollisionDetectionStrategy
    {
        /// <summary>
        /// No collision detection.
        /// </summary>
        None = 0,
        
        /// <summary>
        /// Detects collisions with colliders.
        /// </summary>
        Colliders = 1,
        
        /// <summary>
        /// Detects collisions with trigger colliders.
        /// </summary>
        TriggerColliders = 2
    }
}