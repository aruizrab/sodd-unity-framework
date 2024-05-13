using System;
using SODD.Core;
using UnityEngine;
using UnityEngine.Events;

namespace SODD.Observers
{
    /// <summary>
    ///     Represents a component that observes changes in a <see cref="Variables.BoolVariable" />'s value and triggers
    ///     UnityEvents in response.
    /// </summary>
    /// <remarks>
    ///     This class extends <see cref="VariableObserver{T}" /> by adding functionality to convert the boolean value to a
    ///     string in different formats (lowercase, uppercase, or capitalized) and trigger an event when the string value
    ///     changes.
    ///     This feature can be useful for UI elements where boolean states need to be displayed textually.
    /// </remarks>
    [AddComponentMenu(Framework.VariableObservers.BoolVariableObserver, Framework.MenuOrders.Bool)]
    public class BoolVariableObserver : VariableObserver<bool>
    {
        [SerializeField] private ToStringContainer getValueAsString;

        protected override void OnVariableValueChanged(bool value)
        {
            base.OnVariableValueChanged(value);

            var stringValue = getValueAsString.toStringStrategy switch
            {
                ToStringStrategy.Lowercase => value.ToString().ToLower(),
                ToStringStrategy.Capitalized => value.ToString(),
                ToStringStrategy.Uppercase => value.ToString().ToUpper(),
                _ => value.ToString()
            };

            getValueAsString.onValueChangedAsString?.Invoke(stringValue);
        }

        [Serializable]
        private class ToStringContainer
        {
            public ToStringStrategy toStringStrategy;
            public UnityEvent<string> onValueChangedAsString;
        }
    }
}