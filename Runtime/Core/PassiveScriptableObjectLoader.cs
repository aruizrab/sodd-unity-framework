﻿using System.Collections.Generic;
using UnityEngine;

namespace SODD.Core
{
    /// <summary>
    ///     Automatically generated component that ensures Passive ScriptableObjects are loaded into memory.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <see cref="PassiveScriptableObjectLoader" /> class is designed to be automatically generated by the SODD
    ///         Framework
    ///         and added to scenes to reference passive ScriptableObjects, ensuring they are kept loaded into memory during
    ///         runtime.
    ///     </para>
    ///     <para>
    ///         This component maintains a list of <see cref="PassiveScriptableObject" /> instances that are required to be
    ///         loaded.
    ///         It is attached to a GameObject that is added to all scenes included in the final build, providing a centralized
    ///         reference to all passive ScriptableObjects, ensuring they are instantiated and available when needed.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Usage example of PassiveScriptableObjectLoader:
    ///     <code>
    /// // This class is automatically generated by the SODD Framework.
    /// // Manual creation or modification is not required.
    /// </code>
    /// </example>
    public sealed class PassiveScriptableObjectLoader : MonoBehaviour
    {
        /// <summary>
        ///     List of passive ScriptableObjects to be loaded into memory.
        /// </summary>
        /// <remarks>
        ///     This list is populated by the SODD Framework during the build process. Each entry corresponds to a
        ///     <see cref="PassiveScriptableObject" /> that is flagged to be loaded into memory.
        /// </remarks>
        public List<PassiveScriptableObject> passiveScriptableObjects;
    }
}