using SODD.Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace SODD.Observers
{
    /// <summary>
    ///     Represents a component that observes changes in a <see cref="Variables.IntVariable" />'s value and triggers
    ///     UnityEvents in response.
    /// </summary>
    [AddComponentMenu(Framework.VariableObservers.IntVariableObserver, Framework.MenuOrders.Int)]
    public class IntVariableObserver : VariableObserver<int>
    {
        [SerializeField] [Collapsible("Get Value As String")]
        public UnityEvent<string> onValueChangedAsString;

        protected override void OnVariableValueChanged(int value)
        {
            base.OnVariableValueChanged(value);
            onValueChangedAsString?.Invoke(value.ToString());
        }
    }
}