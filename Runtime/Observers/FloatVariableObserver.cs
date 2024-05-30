using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

namespace SODD.Observers
{
    /// <summary>
    ///     Represents a component that observes changes in a <see cref="Variables.FloatVariable" />'s value and triggers
    ///     UnityEvents in response.
    /// </summary>
    [AddComponentMenu(Framework.VariableObservers.FloatVariableObserver, Framework.MenuOrders.Float)]
    public class FloatVariableObserver : VariableObserver<float>
    {
        [SerializeField] private ToStringContainer getValueAsString;

        protected override void OnVariableValueChanged(float value)
        {
            base.OnVariableValueChanged(value);

            var roundedValue = getValueAsString.decimals != -1 ? Math.Round(value, getValueAsString.decimals) : value;
            var multipliedValue = roundedValue * getValueAsString.multiplier;
            var stringValue = multipliedValue.ToString(CultureInfo.CurrentCulture);

            getValueAsString.onValueChangedAsString?.Invoke(stringValue);
        }

        [Serializable]
        private class ToStringContainer
        {
            [Tooltip("Specifies the number of decimal places for rounding the float value. Use -1 for no rounding.")]
            public int decimals = 2;
            public int multiplier = 1;

            public UnityEvent<string> onValueChangedAsString;
        }
    }
}