using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SODD.UI
{
    /// <summary>
    ///     A selectable UI component that allows the user to cycle through a list of options.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <see cref="OptionSelector" /> class extends <see cref="Selectable" /> and provides functionality for
    ///         navigating
    ///         through a list of string options. It supports both horizontal and vertical navigation and invokes an event
    ///         when an option is selected.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Example usage of the <see cref="OptionSelector" /> class:
    ///     <code>
    /// [SerializeField]
    /// private OptionSelector optionSelector;
    /// 
    /// void Start()
    /// {
    ///     optionSelector.SetOptions(new List&lt;string&gt; { "Option 1", "Option 2", "Option 3" });
    ///     optionSelector.onOptionSelected.AddListener(OnOptionSelected);
    /// }
    /// 
    /// private void OnOptionSelected(int index)
    /// {
    ///     Debug.Log("Selected option index: " + index);
    /// }
    /// </code>
    /// </example>
    public class OptionSelector : Selectable
    {
        /// <summary>
        ///     The text component that displays the current option.
        /// </summary>
        [SerializeField] [Tooltip("The text component that displays the current option.")]
        private TMP_Text text;

        /// <summary>
        ///     The axis on which the options can be navigated.
        /// </summary>
        [SerializeField] [Tooltip("The axis on which the options can be navigated.")]
        private Axis axis;

        /// <summary>
        ///     The list of options to select from.
        /// </summary>
        [SerializeField] [Tooltip("The list of options to select from.")]
        private List<string> options;

        /// <summary>
        ///     Event invoked when an option is selected.
        /// </summary>
        [SerializeField] [Tooltip("Event invoked when an option is selected.")]
        private UnityEvent<int> onOptionSelected;

        private int _currentIndex;

        /// <summary>
        ///     Gets or sets the current index of the selected option.
        /// </summary>
        public int Value
        {
            get => _currentIndex;
            set
            {
                SetValueWithoutNotify(value);
                onOptionSelected?.Invoke(value);
            }
        }

        /// <summary>
        ///     Sets the list of options to select from.
        /// </summary>
        /// <param name="optionsList">The list of options.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="optionsList" /> is null.</exception>
        public void SetOptions([NotNull] List<string> optionsList)
        {
            options = optionsList ?? throw new ArgumentNullException(nameof(optionsList));
            _currentIndex = 0;
        }

        /// <summary>
        ///     Adds an option to the list of options.
        /// </summary>
        /// <param name="option">The option to add.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="option" /> is null.</exception>
        public void AddOption([NotNull] string option)
        {
            if (option == null) throw new ArgumentNullException(nameof(option));
            options.Add(option);
            _currentIndex = 0;
        }

        /// <summary>
        ///     Adds a list of options to the existing options.
        /// </summary>
        /// <param name="optionsList">The list of options to add.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="optionsList" /> is null.</exception>
        public void AddOptions([NotNull] List<string> optionsList)
        {
            if (optionsList == null) throw new ArgumentNullException(nameof(optionsList));
            options.AddRange(optionsList);
            _currentIndex = 0;
        }

        /// <summary>
        ///     Selects the next option in the list.
        /// </summary>
        public void SelectNext()
        {
            Value = GetNextIndex();
        }

        /// <summary>
        ///     Selects the previous option in the list.
        /// </summary>
        public void SelectPrevious()
        {
            Value = GetPreviousIndex();
        }

        private int GetNextIndex()
        {
            _currentIndex++;
            if (_currentIndex >= options.Count) _currentIndex = 0;
            return _currentIndex;
        }

        private int GetPreviousIndex()
        {
            _currentIndex--;
            if (_currentIndex < 0) _currentIndex = options.Count - 1;
            return _currentIndex;
        }

        /// <summary>
        ///     Handles navigation events for the option selector.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        public override void OnMove(AxisEventData eventData)
        {
            if (!IsActive() || !IsInteractable())
            {
                base.OnMove(eventData);
                return;
            }

            switch (eventData.moveDir)
            {
                case MoveDirection.Left when axis == Axis.Horizontal:
                    if (FindSelectableOnLeft() == null) SelectPrevious();
                    else base.OnMove(eventData);
                    break;
                case MoveDirection.Right when axis == Axis.Horizontal:
                    if (FindSelectableOnRight() == null) SelectNext();
                    else base.OnMove(eventData);
                    break;
                case MoveDirection.Up when axis == Axis.Vertical:
                    if (FindSelectableOnUp() == null) SelectPrevious();
                    else base.OnMove(eventData);
                    break;
                case MoveDirection.Down when axis == Axis.Vertical:
                    if (FindSelectableOnDown() == null) SelectNext();
                    else base.OnMove(eventData);
                    break;
                case MoveDirection.None:
                default:
                    base.OnMove(eventData);
                    break;
            }
        }

        /// <summary>
        ///     Sets the value without invoking the option selected event.
        /// </summary>
        /// <param name="value">The index of the option to select.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value" /> is out of range.</exception>
        public void SetValueWithoutNotify(int value)
        {
            if (value < 0 || value >= options.Count) throw new ArgumentOutOfRangeException(nameof(value));
            _currentIndex = value;
            text.text = options[_currentIndex];
        }

        /// <summary>
        ///     Defines the axes for navigation.
        /// </summary>
        [Flags]
        private enum Axis
        {
            Horizontal,
            Vertical
        }
    }
}