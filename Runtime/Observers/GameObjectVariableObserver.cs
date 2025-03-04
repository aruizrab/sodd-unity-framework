using UnityEngine;
using UnityEngine.Events;

namespace SODD.Observers
{
    /// <summary>
    ///     Represents a component that observes changes in a <see cref="Variables.GameObjectVariable" />’s value and triggers
    ///     UnityEvents in response.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The GameObjectVariableObserver class inherits from <see cref="VariableObserver{T}" /> where <c>T</c> is a
    ///         GameObject.
    ///         It monitors changes in a GameObject variable and triggers one of two events based on whether a value is
    ///         available
    ///         (non-null) or not available (null).
    ///     </para>
    ///     <para>
    ///         This observer is useful for enabling or disabling behaviors, UI elements, or other components depending on the
    ///         presence of a GameObject.
    ///     </para>
    /// </remarks>
    [AddComponentMenu(Framework.VariableObservers.GameObjectVariableObserver, Framework.MenuOrders.GameObject)]
    public class GameObjectVariableObserver : VariableObserver<GameObject>
    {
        [SerializeField] private UnityEvent onValueAvailable;
        [SerializeField] private UnityEvent onValueNotAvailable;

        protected override void OnVariableValueChanged(GameObject value)
        {
            base.OnVariableValueChanged(value);
            (value ? onValueAvailable : onValueNotAvailable)?.Invoke();
        }
    }
}