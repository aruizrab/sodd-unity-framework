using UnityEngine;
#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif

namespace SODD.Core
{
    /// <summary>
    ///     Provides utility functions for logging in the Unity Editor.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        ///     Logs a message associated with a specific Unity asset in the console, including a clickable link to the asset in
        ///     the editor.
        /// </summary>
        /// <param name="asset">The asset related to the message.</param>
        /// <param name="message">The message to log.</param>
        /// <remarks>
        ///     This method enhances debugging and logging in the Unity Editor by providing a direct link to the asset involved,
        ///     making it easier to identify and access assets directly from the console log. Only available in the Unity Editor.
        /// </remarks>
        /// <example>
        ///     Example of logging an asset-related message:
        ///     <code>
        /// // Assuming 'exampleAsset' is a Unity asset, such as a ScriptableObject
        /// Logger.LogAsset(exampleAsset, "This is a test message for logging purposes.");
        /// </code>
        ///     This will output a log message in the Unity console with a clickable link to 'exampleAsset'.
        /// </example>
        public static void LogAsset(Object asset, string message)
        {
#if UNITY_EDITOR
            var assetPath = AssetDatabase.GetAssetPath(asset);
            var filename = Path.GetFileName(assetPath).Replace(".asset", "");
            var linkToCollection = $"<a href=\"{assetPath}\">{filename}</a>";
            
            Debug.Log($"[{asset.GetType().FullName}] {linkToCollection} {message}");
#endif
        }
    }
}