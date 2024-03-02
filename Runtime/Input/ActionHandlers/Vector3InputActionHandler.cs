using UnityEngine;

namespace SODD.Input.ActionHandlers
{
    [CreateAssetMenu(menuName = Framework.Input.ActionHandlers.Vector3, fileName = nameof(Vector3InputActionHandler),
        order = Framework.MenuOrders.Vector3)]
    public sealed class Vector3InputActionHandler : InputActionHandler<Vector3>
    {
    }
}