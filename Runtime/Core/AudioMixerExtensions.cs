using UnityEngine;
using UnityEngine.Audio;

namespace SODD.Core
{
    /// <summary>
    ///     Extends <see cref="AudioMixer" /> type providing utility methods.
    /// </summary>
    public static class AudioMixerExtensions
    {
        /// <summary>
        ///     Sets the volume level of a specific parameter in the AudioMixer.
        /// </summary>
        /// <param name="mixer">The AudioMixer instance.</param>
        /// <param name="name">The name of the parameter whose volume to set.</param>
        /// <param name="percentage">The volume level to set as a percentage (0 to 100).</param>
        /// <remarks>
        ///     This method sets the volume level of the specified parameter in the AudioMixer
        ///     by converting the input percentage from a linear scale to the logarithmic scale (decibels).
        ///     If the input percentage is less than 0, it will be clamped to 0.
        ///     If the input percentage is greater than 100, it will be clamped to 100.
        /// </remarks>
        public static void SetVolume(this AudioMixer mixer, string name, float percentage)
        {
            if (percentage < 0) percentage = 0;
            if (percentage > 100) percentage = 100;
            mixer.SetFloat(name, Mathf.Log10(percentage / 100) * 20);
        }

        /// <summary>
        ///     Gets the volume level of a specific parameter in the AudioMixer.
        /// </summary>
        /// <param name="mixer">The AudioMixer instance.</param>
        /// <param name="name">The name of the parameter whose volume to retrieve.</param>
        /// <param name="percentage">The output variable that will contain the volume level as a percentage (0 to 100).</param>
        /// <returns>
        ///     True if the parameter exists and its volume level was successfully retrieved;
        ///     otherwise, false if the parameter doesn't exist or an error occurred during retrieval.
        /// </returns>
        /// <remarks>
        ///     This method retrieves the volume level of the specified parameter in the AudioMixer
        ///     and converts it from the logarithmic scale (decibels) to a linear scale represented as a percentage.
        /// </remarks>
        public static bool GetVolume(this AudioMixer mixer, string name, out float percentage)
        {
            if (!mixer.GetFloat(name, out percentage)) return false;
            percentage = 100 * Mathf.Pow(10, percentage / 20);
            return true;
        }
    }
}