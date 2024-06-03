using System.Linq;
using SODD.Core;
using SODD.Events;
using SODD.Variables;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace SODD.Input
{
    /// <summary>
    ///     Manages control schemes and handles switching between them based on input device events.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <see cref="ControlSchemeHandler" /> class is responsible for managing control schemes within a Unity
    ///         project.
    ///         It listens to input system events and switches control schemes based on the active input device. This class
    ///         extends <see cref="PassiveScriptableObject" /> to ensure it is loaded into memory during runtime.
    ///     </para>
    ///     <para>
    ///         When an input event is detected from a new device, the control scheme associated with that device is activated.
    ///         The class invokes an event to notify other systems of the control scheme change and updates a variable to
    ///         reflect
    ///         the current control scheme.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Input.ControlSchemeHandler, fileName = nameof(ControlSchemeHandler))]
    public class ControlSchemeHandler : PassiveScriptableObject
    {
        /// <summary>
        /// The input action asset containing the control schemes.
        /// </summary>
        [SerializeField] private InputActionAsset inputActionAsset;
        
        /// <summary>
        /// Event triggered when the control scheme changes.
        /// </summary>
        [SerializeField] private Event<string> onControlSchemeChanged;
        
        /// <summary>
        /// Variable to store the current control scheme name.
        /// </summary>
        [SerializeField] private Variable<string> currentControlScheme;
        
        /// <summary>
        /// Indicates whether the handler should run in the Unity editor.
        /// </summary>
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