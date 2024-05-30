using System.Linq;
using SODD.Core;
using SODD.Events;
using SODD.Variables;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace SODD.Input
{
    [CreateAssetMenu(menuName = Framework.Input.ControlSchemeHandler, fileName = nameof(ControlSchemeHandler))]
    public class ControlSchemeHandler : PassiveScriptableObject
    {
        [SerializeField] private InputActionAsset inputActionAsset;
        [SerializeField] private Event<string> onControlSchemeChanged;
        [SerializeField] private Variable<string> currentControlScheme;
        [SerializeField] private bool runInEditor = false;

        private InputDevice _currentDevice;
        private bool _isListening;

        private void OnEnable()
        {
            InputSystem.onEvent += OnInputSystemEvent;
        }

        private void OnDisable()
        {
            InputSystem.onEvent -= OnInputSystemEvent;
        }

        private void OnInputSystemEvent(InputEventPtr eventPtr, InputDevice device)
        {
#if UNITY_EDITOR
            if (!runInEditor) return;
#endif
            if (!inputActionAsset) return;

            if (_currentDevice != null && _currentDevice == device) return;
            if (eventPtr.type == StateEvent.Type)
                if (!eventPtr.EnumerateChangedControls(device, 0.001f).Any())
                    return;

            _currentDevice = device;

            var controlScheme = inputActionAsset.controlSchemes.FirstOrDefault(scheme => scheme.SupportsDevice(device));

            if (controlScheme == default) return;
            if (onControlSchemeChanged) onControlSchemeChanged.Invoke(controlScheme.name);
            if (currentControlScheme) currentControlScheme.Value = controlScheme.name;
        }
    }
}