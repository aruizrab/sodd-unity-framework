using System;
using System.Linq;
using SODD.Core;
using SODD.Repositories;
using SODD.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SODD.Input
{
    [CreateAssetMenu(menuName = Framework.Input.IconProvider, fileName = nameof(InputActionIconProvider))]
    public class InputActionIconProvider : PassiveScriptableObject
    {
        [SerializeField] private InputActionReference inputActionReference;
        [SerializeField] private InputIconRepository inputIconRepository;
        [SerializeField] private TMP_SpriteAsset targetIcon;
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