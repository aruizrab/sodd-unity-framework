using System;
using System.Globalization;
using SODD.Attributes;
using SODD.Events;
using UnityEngine;

namespace SODD.Variables
{
    /// <summary>
    ///     A ScriptableObject representing a DateTime variable.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The DateTimeVariable class is a specialized implementation of the Variable class for DateTime values.
    ///         It is designed to hold a DateTime value that can be shared across different components and scripts in a Unity
    ///         project,
    ///         allowing for centralized management of date and time data.
    ///     </para>
    ///     <para>
    ///         In addition to the DateTime value, this class exposes several extra fields in the Inspector:
    ///         a string <c>format</c> field to control how the DateTime is converted to a string,
    ///         a <c>formattedValue</c> field that holds the formatted representation of the DateTime value,
    ///         and a <c>localization</c> field to specify the culture for date formatting (defaulting to English).
    ///         The formatted value is automatically updated whenever the DateTime value, its format, or localization changes,
    ///         and any change is broadcast through an event, enabling listeners to react accordingly.
    ///     </para>
    ///     <para>
    ///         A custom editor is provided (in a separate script) to allow manual updating of the DateTime value based on the
    ///         current formatted string, parsing it according to the specified format.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Variables.DateTime, fileName = nameof(DateTimeVariable),
        order = Framework.MenuOrders.DateTime)]
    public class DateTimeVariable : Variable<DateTime>, IVariable
    {
        [SerializeField]
        [Tooltip("The string format to display the DateTime value (e.g., yyyy-MM-dd HH:mm:ss).")]
        [OnValueChanged("HandleValueChange")]
        private string format = "yyyy-MM-dd HH:mm:ss";

        [SerializeField]
        [Tooltip("The culture identifier for date formatting (e.g., 'en' for English, 'fr' for French).")]
        [OnValueChanged("HandleValueChange")]
        private string localization = "en";

        [SerializeField] [Tooltip("The formatted representation of the DateTime value.")]
        private string formattedValue;

        // Event for formatted value changes.
        protected readonly IEvent<string> OnFormattedValueChanged = new GenericEvent<string>();

        /// <summary>
        ///     Gets or sets the string format.
        ///     When updated, the formatted value is recalculated.
        /// </summary>
        public string Format
        {
            get => format;
            set
            {
                if (format != value)
                {
                    format = value;
                    UpdateFormattedValue();
                }
            }
        }

        /// <summary>
        ///     Gets or sets the localization (culture identifier) for date formatting.
        ///     When updated, the formatted value is recalculated.
        /// </summary>
        public string Localization
        {
            get => localization;
            set
            {
                if (localization != value)
                {
                    localization = value;
                    UpdateFormattedValue();
                }
            }
        }

        /// <summary>
        ///     Gets the formatted representation of the DateTime value.
        /// </summary>
        public string FormattedValue => formattedValue;

#if UNITY_EDITOR
        /// <summary>
        ///     Resets the DateTime variable to its default value (DateTime.Now) when the asset is first created.
        ///     This method is called by the Unity Editor when the ScriptableObject is instantiated.
        /// </summary>
        protected override void Reset()
        {
            Value = DateTime.Now;
        }
#endif

        object IVariable.Value
        {
            get =>
                new Data
                {
                    format = format,
                    localization = localization,
                    formattedValue = formattedValue
                };
            set
            {
                if (value is Data data)
                {
                    format = data.format;
                    localization = data.localization;
                    formattedValue = data.formattedValue;
                    Value = DateTime.ParseExact(formattedValue, format, CultureInfo.GetCultureInfo(localization));
                }
                else
                {
                    Reset();
                }
            }
        }

        /// <summary>
        ///     Registers a listener for changes in the formatted DateTime string.
        /// </summary>
        /// <param name="listener">The action to be invoked when the formatted value changes.</param>
        public void AddFormattedListener(Action<string> listener)
        {
            OnFormattedValueChanged.AddListener(listener);
        }

        /// <summary>
        ///     Unregisters a listener from the formatted DateTime string change event.
        /// </summary>
        /// <param name="listener">The action to remove from the listener list.</param>
        public void RemoveFormattedListener(Action<string> listener)
        {
            OnFormattedValueChanged.RemoveListener(listener);
        }

        /// <summary>
        ///     Overrides the base value change handler to update the formatted string whenever the DateTime value changes.
        /// </summary>
        protected override void HandleValueChange()
        {
            UpdateFormattedValue();
            base.HandleValueChange();
        }

        /// <summary>
        ///     Updates the <c>formattedValue</c> field based on the current DateTime value and format,
        ///     and notifies any listeners about the change.
        /// </summary>
        protected void UpdateFormattedValue()
        {
            try
            {
                var culture = CultureInfo.GetCultureInfo(localization);
                formattedValue = value.ToString(format, culture);
            }
            catch (Exception)
            {
                formattedValue = value.ToString(format);
            }

            OnFormattedValueChanged?.Invoke(formattedValue);
        }

        [Serializable]
        internal class Data
        {
            public string format;
            public string localization;
            public string formattedValue;
        }
    }
}