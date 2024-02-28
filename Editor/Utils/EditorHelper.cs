using System.IO;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Utils
{
    /// <summary>
    ///     Provides utility methods for working with the Unity editor.
    /// </summary>
    internal static class EditorHelper
    {
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
        /// <remarks>
        ///     This method creates a new game object with a specified component of type T and sets it as a child of the selected
        ///     game object.
        ///     It also sets the name of the game object to a human-readable format based on the name of the specified component
        ///     type.
        ///     Finally, it registers the new game object with the Undo system and makes it the active object in the Unity Editor's
        ///     selection.
        /// </remarks>
        public static void CreateGameObject<T>(GameObject parent) where T : Component
        {
            var obj = new GameObject(ObjectNames.NicifyVariableName(typeof(T).Name));
            obj.AddComponent<T>();
            GameObjectUtility.SetParentAndAlign(obj, parent);
            Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
            Selection.activeObject = obj;
        }
    }
}