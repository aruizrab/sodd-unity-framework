using System;
using SODD.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace SODD.Observers
{
    /// <summary>
    ///     Represents a component that observes changes in a <see cref="Variables.DateTimeVariable"/>’s value and triggers
    ///     UnityEvents in response to changes in its formatted string representation.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The DateTimeVariableObserver class inherits from <see cref="VariableObserver{T}"/> where <c>T</c> is a DateTime.
    ///         It monitors changes in a DateTime variable and specifically observes the formatted string value, which can be localized.
    ///     </para>
    ///     <para>
    ///         When the formatted value of the DateTime variable changes, the observer triggers the <c>onStringValueChanged</c> event,
    ///         allowing UI elements or other components to react to date and time updates in a human-readable format.
    ///     </para>
    /// </remarks>
    [AddComponentMenu(Framework.VariableObservers.DateTimeVariableObserver, Framework.MenuOrders.DateTime)]
    public class DateTimeVariableObserver : VariableObserver<DateTime>
    {
        [SerializeField] private UnityEvent<string> onStringValueChanged;

        protected override void OnEnable()
        {
            base.OnEnable();
            var variable = (DateTimeVariable) targetVariable;
            if (initialValueCheck) OnStringValueChanged(variable.FormattedValue);
            variable.AddFormattedListener(OnStringValueChanged);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            var variable = (DateTimeVariable) targetVariable;
            variable.RemoveFormattedListener(OnStringValueChanged);
        }

        protected void OnStringValueChanged(string value)
        {
            onStringValueChanged?.Invoke(value);
        }
    }
}