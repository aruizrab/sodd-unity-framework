using SODD.Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace SODD.Observers
{
    /// <summary>
    ///     Represents a component that observes changes in a <see cref="Variables.Vector3Variable" />'s value and triggers
    ///     UnityEvents in response.
    /// </summary>
    [AddComponentMenu(Framework.VariableObservers.Vector3VariableObserver, Framework.MenuOrders.Vector3)]
    public class Vector3VariableObserver : VariableObserver<Vector3>
    {
        [SerializeField] [Collapsible("Get Value As String")]
        public UnityEvent<string> onValueChangedAsString;

        protected override void OnVariableValueChanged(Vector3 value)
        {
            base.OnVariableValueChanged(value);
            onValueChangedAsString?.Invoke(value.ToString());
        }
    }
}