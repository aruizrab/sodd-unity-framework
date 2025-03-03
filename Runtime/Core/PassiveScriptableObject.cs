using UnityEngine;

namespace SODD.Core
{
    /// <summary>
    ///     Represents a passive ScriptableObject that ensures it is loaded into memory during runtime.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <see cref="PassiveScriptableObject" /> class is designed for ScriptableObjects that do not populate a scene
    ///         but need to provide functionality passively as assets loaded into memory. It includes a mechanism to ensure
    ///         these ScriptableObjects are referenced and loaded into memory during runtime.
    ///     </para>
    ///     <para>
    ///         Each instance of a <see cref="PassiveScriptableObject" /> includes a toggle option in the Inspector, which is
    ///         enabled by default, indicating whether the specific instance should be loaded into memory. This class is part
    ///         of the SODD Framework's approach to managing ScriptableObject-based systems that interact with features such
    ///         as Input Action Handlers or Control Scheme Handlers.
    ///     </para>
    ///     <para>
    ///         The SODD Framework provides a menu option that scans the project files for
    ///         <see cref="PassiveScriptableObject" />
    ///         instances with the enabled toggle option. It then creates a GameObject with a Component that contains a list
    ///         of all the collected <see cref="PassiveScriptableObject" /> instances, ensuring they are loaded into memory
    ///         during runtime.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Definition of a custom passive ScriptableObject:
    ///     <code>
    /// [CreateAssetMenu(menuName = "My ScriptableObjects/Custom Passive SO", fileName = nameof(CustomPassiveSO))]
    /// public class CustomPassiveSO : PassiveScriptableObject
    /// {
    ///     // Custom implementation details
    /// }
    /// </code>
    /// </example>
    public abstract class PassiveScriptableObject : ScriptableObject
    {
        /// <summary>
        ///     Indicates whether this instance should be loaded into memory.
        /// </summary>
        /// <remarks>
        ///     This toggle option, enabled by default, determines if the specific instance of the
        ///     <see cref="PassiveScriptableObject" /> should be included in the memory loading process.
        /// </remarks>
        [Tooltip("Enable this to ensure the instance is loaded into memory during runtime.")]
        public bool reference = true;
    }
}