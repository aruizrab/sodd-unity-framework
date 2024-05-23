using System;

namespace SODD.AI
{
    [Flags]
    public enum CollisionDetectionStrategy
    {
        None = 0,
        Colliders = 1,
        TriggerColliders = 2
    }
}