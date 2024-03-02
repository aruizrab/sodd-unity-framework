using UnityEngine;

namespace SODD.Input.ActionHandlers
{
    /// <summary>
    ///     A ScriptableObject that handles input actions passing float data.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <c>FloatInputActionHandler</c> specializes in processing input actions that output float data, such as
    ///         analog stick movement,
    ///         trigger pressure, or any other input mechanism that generates a continuous range of values rather than discrete
    ///         on/off signals.
    ///     </para>
    ///     <para>
    ///         This handler is ideal for scenarios where the precise value of an input, within a defined range, influences the
    ///         game's behavior.
    ///         Examples include adjusting the speed of a character's movement based on analog stick deflection or modulating
    ///         audio volume.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Input.ActionHandlers.Float, fileName = nameof(FloatInputActionHandler),
        order = Framework.MenuOrders.Float)]
    public sealed class FloatInputActionHandler : InputActionHandler<float>
    {
    }
}