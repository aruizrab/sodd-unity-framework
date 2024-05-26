using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SODD.Editor.Utils
{
    /// <summary>
    ///     Provides utility methods for working with the Unity editor.
    /// </summary>
    internal static class EditorHelper
    {
        private static readonly BindingFlags PropertyBindingFlags =
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        /// <summary>
        ///     Creates an instance of a ScriptableObject of type T and saves it as an asset in the Unity project.
        /// </summary>
        /// <typeparam name="T">The type of ScriptableObject to create.</typeparam>
        public static void CreateScriptableObject<T>() where T : ScriptableObject
        {
            var asset = ScriptableObject.CreateInstance<T>();
            var path = "Assets";

            foreach (var selected in Selection.GetFiltered<Object>(SelectionMode.Assets))
            {
                path = AssetDatabase.GetAssetPath(selected);
                if (File.Exists(path)) path = Path.GetDirectoryName(path);
                break;
            }

            path += $"/{ObjectNames.NicifyVariableName(asset.GetType().Name)}.asset";
            ProjectWindowUtil.CreateAsset(asset, path);
        }

        /// <summary>
        ///     Creates a new game object with a specified component and sets it as a child of the selected game object.
        /// </summary>
        /// <typeparam name="T">The type of component to add to the new game object.</typeparam>
        /// <param name="parent">The selected game object under which the new game object will be created as a child.</param>
        /// <param name="setIconToGameObject"></param>
        /// <remarks>
        ///     This method creates a new game object with a specified component of type T and sets it as a child of the selected
        ///     game object.
        ///     It also sets the name of the game object to a human-readable format based on the name of the specified component
        ///     type.
        ///     Finally, it registers the new game object with the Undo system and makes it the active object in the Unity Editor's
        ///     selection.
        /// </remarks>
        public static void CreateGameObject<T>(GameObject parent, bool setIconToGameObject = false) where T : Component
        {
            var obj = new GameObject(ObjectNames.NicifyVariableName(typeof(T).Name));
            var component = obj.AddComponent<T>();
            GameObjectUtility.SetParentAndAlign(obj, parent);

            if (setIconToGameObject)
            {
                var icon = EditorGUIUtility.GetIconForObject(component);
                EditorGUIUtility.SetIconForObject(obj, icon);
            }

            Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
            Selection.activeObject = obj;
            EditorApplication.delayCall += () =>
            {
                EditorApplication.ExecuteMenuItem("Window/General/Hierarchy");
                Selection.activeObject = obj;
                var hierarchyWindow = EditorWindow.focusedWindow;
                if (hierarchyWindow == null) return;
                if (Selection.activeObject != obj) return;
                var renameEvent = new Event
                {
                    type = EventType.ExecuteCommand,
                    commandName = "Rename"
                };
                hierarchyWindow.SendEvent(renameEvent);
            };
        }

        public static object GetValue(SerializedProperty property, string name)
        {
            var path = property.propertyPath.Contains(".")
                ? Path.ChangeExtension(property.propertyPath, name)
                : name;
            var serializedProperty = property.serializedObject.FindProperty(path)
                                     ?? throw new Exception($"Cannot find {path}.");
            var targetObject = serializedProperty.serializedObject.targetObject;
            var field = targetObject.GetType().GetField(serializedProperty.propertyPath, PropertyBindingFlags)
                        ?? throw new Exception($"Cannot get field {serializedProperty.propertyPath}.");
            return field.GetValue(targetObject);
        }
        
        [MenuItem("Tools/Reload Resources")]
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
    }
}