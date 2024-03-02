using SODD.Editor.Utils;
using SODD.Input.ActionHandlers;
using UnityEditor;

namespace SODD.Editor.Input.ActionHandlers
{
    /// <summary>
    ///     A ScriptableObject responsible for handling input actions that produce a <see cref="Vector3" /> value.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The `Vector3InputActionHandler` specializes in processing input actions associated with three-dimensional
    ///         movement or directional input, such as joystick movements in 3D space, or more complex scenarios where
    ///         an input generates a three-dimensional vector. It is particularly useful in 3D games for camera control,
    ///         character movement in three axes, or any gameplay mechanism requiring three-dimensional directional input.
    ///     </para>
    /// </remarks>
    public static class Vector3InputActionHandlerMenu
    {
        [MenuItem("Tools/" + Framework.Input.ActionHandlers.Vector3, priority = Framework.MenuOrders.Vector3)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<Vector3InputActionHandler>();
        }
    }
}