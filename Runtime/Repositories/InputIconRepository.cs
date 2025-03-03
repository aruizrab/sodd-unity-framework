using System.Linq;
using SODD.Core;
using SODD.Data;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SODD.Repositories
{
    /// <summary>
    ///     Provides a repository for input action icons, mapping input actions to their respective icons.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <see cref="InputIconRepository" /> class manages a dictionary of input actions and their corresponding
    ///         icons.
    ///         It allows for retrieving the appropriate icon based on an input action path, facilitating the display of
    ///         correct
    ///         icons in the UI depending on the active control scheme.
    ///     </para>
    ///     <para>
    ///         This class extends <see cref="PassiveScriptableObject" /> to ensure it is loaded into memory during runtime and
    ///         can be accessed by other systems that require input action icons.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Repositories.InputIconRepository, fileName = nameof(InputIconRepository))]
    public class InputIconRepository : PassiveScriptableObject
    {
        /// <summary>
        ///     The default icon to use when no matching icon is found.
        /// </summary>
        [SerializeField] private Sprite defaultIcon;

        /// <summary>
        ///     A dictionary mapping input actions to their corresponding icons.
        /// </summary>
        [SerializeField] private SerializableDictionary<InputAction, Sprite> iconMap;

        /// <summary>
        ///     Retrieves the icon associated with a given input action path.
        /// </summary>
        /// <param name="path">The path of the input action.</param>
        /// <returns>The associated icon if found; otherwise, the default icon.</returns>
        /// <remarks>
        ///     This method searches the icon map for an icon associated with the specified input action path. If no matching
        ///     icon is found, the default icon is returned.
        /// </remarks>
        public Sprite GetIcon(string path)
        {
            foreach (var pair in from pair in iconMap
                     let bindings = pair.Key.bindings
                     where bindings.Any(binding => binding.path.Equals(path))
                     select pair)
                return pair.Value;

            return defaultIcon;
        }
    }
}