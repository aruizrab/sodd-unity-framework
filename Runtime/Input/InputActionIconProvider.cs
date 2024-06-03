using System.Linq;
using SODD.Core;
using SODD.Repositories;
using SODD.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SODD.Input
{
    /// <summary>
    ///     Provides input action icons based on the current control scheme.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <see cref="InputActionIconProvider" /> class is responsible for providing icons representing input actions
    ///         based on the current control scheme.
    ///         It listens for changes in the control scheme and updates the displayed icon accordingly. This class extends
    ///         <see cref="PassiveScriptableObject" />
    ///         to ensure it is loaded into memory during runtime.
    ///     </para>
    ///     <para>
    ///         This class uses an <see cref="InputIconRepository" /> to fetch the appropriate icons for different input
    ///         actions and control schemes. The icons are then
    ///         applied to a target <see cref="TMP_SpriteAsset" /> for display.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Input.IconProvider, fileName = nameof(InputActionIconProvider))]
    public class InputActionIconProvider : PassiveScriptableObject
    {
        /// <summary>
        ///     The input action reference.
        /// </summary>
        [SerializeField] private InputActionReference inputActionReference;

        /// <summary>
        ///     The repository containing input icons.
        /// </summary>
        [SerializeField] private InputIconRepository inputIconRepository;

        /// <summary>
        ///     The target sprite asset to update with the input action icon.
        /// </summary>
        [SerializeField] private TMP_SpriteAsset targetIcon;

        /// <summary>
        ///     The variable storing the current control scheme.
        /// </summary>
        [SerializeField] private Variable<string> currentControlScheme;

        private void OnEnable()
        {
            if (currentControlScheme) OnControlSchemeChanged(currentControlScheme.Value);
            currentControlScheme?.AddListener(OnControlSchemeChanged);
        }

        private void OnDisable()
        {
            currentControlScheme?.RemoveListener(OnControlSchemeChanged);
        }

        private void OnControlSchemeChanged(string controlSchemeName)
        {
            if (!inputActionReference || !inputIconRepository || !targetIcon || !currentControlScheme) return;

            var inputAction = inputActionReference.action;
            var controlScheme =
                inputActionReference.asset.controlSchemes.FirstOrDefault(scheme =>
                    scheme.name == controlSchemeName);

            if (controlScheme == default) return;

            var bindingIndex = inputAction.GetBindingIndex(controlScheme.bindingGroup);
            var binding = inputAction.bindings[bindingIndex];
            var path = binding.hasOverrides ? binding.overridePath : binding.path;
            var sprite = inputIconRepository.GetIcon(path);

            targetIcon.material.SetTexture(ShaderUtilities.ID_MainTex, sprite.texture);
        }
    }
}