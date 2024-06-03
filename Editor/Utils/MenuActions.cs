using System.Linq;
using SODD.Core;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SODD.Editor.Utils
{
    public static class MenuActions
    {
        // [MenuItem("Tools/Reload Resources")]
        public static void ReloadScriptableObjects()
        {
            var assetPaths = AssetDatabase.GetAllAssetPaths();
            var scriptableObjectPaths = assetPaths
                .Where(assetPath => assetPath.StartsWith("Assets/Resources") && assetPath.EndsWith(".asset")).ToList();
            var totalObjects = scriptableObjectPaths.Count;

            for (var i = 0; i < totalObjects; i++)
            {
                var path = scriptableObjectPaths[i];
                var scriptableObject = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);
                if (scriptableObject != null)
                {
                    EditorUtility.SetDirty(scriptableObject);
                    AssetDatabase.SaveAssetIfDirty(scriptableObject);
                    Debug.Log("Reloaded resource: " + path);
                }

                EditorUtility.DisplayProgressBar("Reloading resources", $"Processing {path}", (float)i / totalObjects);
            }

            EditorUtility.ClearProgressBar();
            AssetDatabase.Refresh();
            Debug.Log("Finished reloading resources.");
        }

        [MenuItem("Tools/Add References to Passive ScriptableObjects")]
        public static void ShowWindow()
        {
            var passiveScriptableObjects = AssetDatabase
                .FindAssets("t:PassiveScriptableObject")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<PassiveScriptableObject>)
                .Where(asset => asset && asset.reference)
                .ToList();

            if (passiveScriptableObjects.Count == 0)
            {
                Debug.Log("No PassiveScriptableObject assets found with reference set to true.");
                return;
            }

            EditorBuildSettings.scenes
                .Where(scene => scene.enabled)
                .Select(scene => scene.path)
                .ForEach(path =>
                {
                    var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(path);
                    if (!sceneAsset) return;

                    EditorSceneManager.OpenScene(path, OpenSceneMode.Single);

                    var loaderObject = GameObject.Find("Passive ScriptableObject Loader");
                    if (!loaderObject) loaderObject = new GameObject("Passive ScriptableObject Loader");

                    var loaderComponent = loaderObject.GetComponent<PassiveScriptableObjectLoader>();
                    if (!loaderComponent)
                        loaderComponent = loaderObject.AddComponent<PassiveScriptableObjectLoader>();

                    loaderComponent.passiveScriptableObjects = passiveScriptableObjects;

                    EditorSceneManager.MarkSceneDirty(loaderObject.scene);
                    EditorSceneManager.SaveScene(loaderObject.scene);
                });

            AssetDatabase.Refresh();
        }
    }
}