using UnityEngine;
#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif

namespace SODD.Core
{
    public static class Logger
    {
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