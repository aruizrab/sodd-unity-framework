using UnityEngine;

namespace SODD.Events
{
    /// <summary>
    ///     Represents a scriptable event that carries a GameObject payload.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This class extends the generic <see cref="Event{T}" /> class, specifying <c>GameObject</c> as the type
    ///         parameter.
    ///         It is designed to handle events that involve GameObjects, such as spawning, transformations, or inventory
    ///         management.
    ///     </para>
    ///     <para>
    ///         Typical use cases include adding or removing items from an inventory, activating or deactivating game
    ///         objects, or any scenario where GameObjects are manipulated dynamically during gameplay.
    ///     </para>
    ///     <para>
    ///         This class can be created as a ScriptableObject asset directly from the Unity Editor.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Below is an example demonstrating how to define and use a <see cref="GameObjectEvent" /> to manage an inventory
    ///     system in a game:
    ///     <code>
    /// public class InventoryManager : MonoBehaviour
    /// {
    ///     public GameObjectEvent onAddInventoryItem; // Assign this through the Unity Editor.
    ///     public GameObjectEvent onRemoveInventoryItem; // Assign this through the Unity Editor.
    /// 
    ///     private List&lt;GameObject&gt; _inventory = new();
    /// 
    ///     private void OnEnable()
    ///     {
    ///         onAddInventoryItem.AddListener(OnAddInventoryItem);
    ///         onRemoveInventoryItem.AddListener(OnRemoveInventoryItem);
    ///     }
    /// 
    ///     private void OnDisable()
    ///     {
    ///         onAddInventoryItem.RemoveListener(OnAddInventoryItem);
    ///         onRemoveInventoryItem.RemoveListener(OnRemoveInventoryItem);
    ///     }
    /// 
    ///     private void OnAddInventoryItem(GameObject item)
    ///     {
    ///         _inventory.Add(item);
    ///     }
    /// 
    ///     private void OnRemoveInventoryItem(GameObject item)
    ///     {
    ///         _inventory.Remove(item);
    ///     }
    /// }
    /// </code>
    ///     This example illustrates how the <c>onAddInventoryItem</c> and <c>onRemoveInventoryItem</c> events can be used to
    ///     manage the items in the player's inventory, enabling the InventoryManager to react to changes without directly
    ///     interacting with the game objects that trigger these changes.
    /// </example>
    [CreateAssetMenu(menuName = Framework.Events.GameObject, fileName = nameof(GameObjectEvent), order = Framework.MenuOrders.GameObject)]
    public sealed class GameObjectEvent : Event<GameObject>
    {
    }
}