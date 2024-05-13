using SODD.Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace SODD.Observers
{
    /// <summary>
    ///     Represents a component that observes changes in a <see cref="Variables.Vector2Variable" />'s value and triggers
    ///     UnityEvents in response.
    /// </summary>
    [AddComponentMenu(Framework.VariableObservers.Vector2VariableObserver, Framework.MenuOrders.Vector2)]
    public class Vector2VariableObserver : VariableObserver<Vector2>
    {
        [SerializeField] [Collapsible("Get Value As String")]
        public UnityEvent<string> onValueChangedAsString;

        protected override void OnVariableValueChanged(Vector2 value)
        {
            base.OnVariableValueChanged(value);
            onValueChangedAsString?.Invoke(value.ToString());
        }
    }
}