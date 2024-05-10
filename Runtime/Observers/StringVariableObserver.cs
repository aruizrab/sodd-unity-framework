using UnityEngine;

namespace SODD.Observers
{
    /// <summary>
    ///     Represents a component that observes changes in a <see cref="Variables.StringVariable" />'s value and triggers
    ///     UnityEvents in response.
    /// </summary>
    /// <remarks>
    ///     This class inherits from the <see cref="VariableObserver{T}" /> where <c>T</c> is a string.
    ///     It provides a ready-to-use observer component that can be attached to any GameObject to monitor changes in string
    ///     variables.
    ///     This observer does not implement additional logic; it utilizes the functionality provided by its base class
    ///     to link string variable changes directly to Unity events.
    /// </remarks>
    [AddComponentMenu(Framework.VariableObservers.StringVariableObserver, Framework.MenuOrders.String)]
    public class StringVariableObserver : VariableObserver<string>
    {
    }
}