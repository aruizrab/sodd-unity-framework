using UnityEngine;

namespace SODD.Collections
{
    /// <summary>
    ///     Represents a scriptable collection that stores <see cref="AudioClip" /> objects.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This collection provides a concrete implementation of the abstract <see cref="Collection{T}" /> class,
    ///         specifically for managing audio clips within a game. It facilitates the organized storage and access
    ///         of sound assets, such as music tracks, sound effects, and other audio samples, which can be manipulated
    ///         and referenced dynamically throughout the game's lifecycle.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Example of using an <see cref="AudioClipCollection" /> to play audio at a specific location triggered by an event:
    ///     <code>
    /// using UnityEngine;
    /// using SODD.Collections;
    /// using SODD.Events;
    /// 
    /// public class Example : MonoBehaviour
    /// {
    ///     public AudioClipCollection shotsAudioPool; // Assign this through the Unity Editor.
    ///     public Vector3Event onShotFired; // Assign this through the Unity Editor.
    /// 
    ///     private void OnEnable()
    ///     {
    ///         onShotFired.AddListener(OnShotFired);
    ///     }
    /// 
    ///     private void OnDisable()
    ///     {
    ///         onShotFired.RemoveListener(OnShotFired);
    ///     }
    /// 
    ///     private void OnShotFired(Vector3 position)
    ///     {
    ///         var audioClip = shotsAudioPool.GetRandom();
    ///         AudioSource.PlayClipAtPoint(audioClip, position);
    ///     }
    /// }
    /// </code>
    ///     This script demonstrates how an <see cref="AudioClipCollection" /> can be used in conjunction with a
    ///     <see cref="Events.Vector3Event" />
    ///     to play a random audio clip from a collection at the position specified by the event.
    /// </example>
    [CreateAssetMenu(menuName = Framework.Collections.AudioClip, fileName = nameof(AudioClipCollection),
        order = Framework.MenuOrders.AudioClip)]
    public sealed class AudioClipCollection : Collection<AudioClip>
    {
    }
}