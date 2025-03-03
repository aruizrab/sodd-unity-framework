using UnityEngine;

namespace SODD.Core
{
    /// <summary>
    ///     Represents a ScriptableObject that can be persisted across game sessions.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <see cref="PersistentScriptableObject" /> class is designed to enable persistent storage and retrieval of
    ///         Scriptable Variables within the SODD Framework. It serves as the base class for variables that need to be saved
    ///         and loaded across game sessions, such as player settings and game states.
    ///     </para>
    ///     <para>
    ///         Each instance of a <see cref="PersistentScriptableObject" /> includes a toggle option in the Inspector, which
    ///         indicates
    ///         whether the specific variable should be persisted. This toggle option facilitates the management of variables
    ///         in the
    ///         Variable Repository, ensuring that only those marked for persistence are saved and loaded.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Definition of a custom persistent ScriptableObject:
    ///     <code>
    /// [CreateAssetMenu(menuName = "My ScriptableObjects/Custom Persistent SO", fileName = nameof(CustomPersistentSO))]
    /// public class CustomPersistentSO : PersistentScriptableObject
    /// {
    ///     // Custom implementation details
    /// }
    /// </code>
    /// </example>
    public abstract class PersistentScriptableObject : ScriptableObject
    {
        /// <summary>
        ///     Indicates whether this variable should be persisted across game sessions.
        /// </summary>
        /// <remarks>
        ///     This toggle option determines if the specific instance of the <see cref="PersistentScriptableObject" /> should be
        ///     included in the persistence process managed by the Variable Repository.
        /// </remarks>
        [Tooltip("Enable this to ensure the variable is saved and loaded across game sessions.")]
        public bool persist;
    }
}