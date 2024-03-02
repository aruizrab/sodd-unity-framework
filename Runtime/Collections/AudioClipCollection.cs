using UnityEngine;

namespace SODD.Collections
{
    /// <summary>
    ///     Represents a collection that stores AudioClips.
    /// </summary>
    /// <seealso cref="Collection{T}" />
    [CreateAssetMenu(menuName = Framework.Collections.AudioClip, fileName = nameof(AudioClipCollection),
        order = Framework.MenuOrders.AudioClip)]
    public sealed class AudioClipCollection : Collection<AudioClip>
    {
    }
}