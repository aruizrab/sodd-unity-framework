# Scriptable Collections

## Concept

At its core, a Scriptable Collection is a Scriptable Object employed to maintain a dynamic list of items or objects
during the game's runtime. This list can be constantly updated, with items being added or removed as the game
progresses. The key feature of Scriptable Collection is their ability to function as central repositories for specific
types of objects, such as enemies, collectible items, or interactive game elements.

## How It Works

- **Collection Creation**: A Scriptable Collection is created as a ScriptableObject, maintaining a list of specific
  types of objects. There are two ways to create these collections:
    - From the **Create menu**: Right-click in the Project window, navigate to `Create > SODD > Collections`, and select
      the
      desired event type (e.g., `GameObjectCollection`).
    - From the **SODD menu**: In the main menu, go to `Tools > SODD > Colelctions`, and choose the desired collection
      type from
      the provided options.
- **Collection Management**: Items can be dynamically added to or removed from the collection during runtime.
- **Inspector Integration**: The current state of the collection can be viewed and modified directly in the Unity
  Inspector, aiding in debugging and testing.
- **Listeners**: Scriptable Collections provide events that are triggered when items are added or removed,
  allowing other components to react to these changes.
- **Persistence**: Collections maintain their state across different scenes within the editor. However, they reset to
  their initial state when the game is restarted in a build.

## Implementations in the Framework

The SODD Framework offers several implementations of Scriptable Collections to cover various use cases. Below is a table
detailing the core collection types included in the framework:

| **Collection Type**       | **Description**                                    |
|---------------------------|----------------------------------------------------|
| **GameObject Collection** | A collection that holds references to GameObjects. |
| **Transform Collection**  | A collection that holds references to Transforms.  |
| **String Collection**     | A collection that holds a set of strings.          |
| **Int Collection**        | A collection that holds a set of integers.         |
| **Float Collection**      | A collection that holds a set of floats.           |
| **Vector2 Collection**    | A collection that holds a set of Vector2s.         |
| **Vector3 Collection**    | A collection that holds a set of Vector3s.         |

## Practical Example

To illustrate the functionality of Scriptable Collections, let's explore a practical use case termed "lock and key."
This scenario involves a door that can only be unlocked by the player using a specific key. The level may contain
multiple doors and keys, but each door requires a distinct key to unlock.

### Step 1: Creating the Player Inventory Collection

First, we need to create a GameObject Collection named "Player Inventory" to represent the player's inventory throughout
the level.

1. Right-click in the Project window of Unity.
2. Navigate to `Create > SODD > Collections > GameObject`.
3. Name the newly created collection `PlayerInventory`.

This collection will now be used to manage the player's inventory items.

### Step 2: Adding Keys to the Inventory

Keys are represented by GameObjects equipped with scripts that, upon collision with the player, add themselves to the "
Player Inventory" collection.

Here’s the code for the `Key` script:

```csharp
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObjectCollection playerInventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInventory.Add(gameObject);
            gameObject.SetActive(false); // Optionally deactivate the key GameObject
        }
    }
}
```

1. Attach the `Key` script to key GameObjects in the scene.
2. Assign the `PlayerInventory` collection to the `playerInventory` field in the Key script.

### Step 3: Unlocking Doors

Each door is a GameObject with a script that references the inventory and the specific key required for unlocking. When
the player collides with a door, the script checks if the required key is present in the player's inventory.

Here’s the code for the `Door` script:

```csharp
using UnityEngine;
using SODD.Collections;

public class Door : MonoBehaviour
{
    public Collection<GameObject> playerInventory;
    public GameObject requiredKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerInventory.Contains(requiredKey))
        {
            UnlockDoor();
        }
    }

    private void UnlockDoor()
    {
        Debug.Log("Door unlocked");
    }
}
```

1. Attach the `Door` script to door GameObjects in the scene.
2. Assign the `PlayerInventory` collection to the `playerInventory` field in the Door script.
3. Assign the specific key GameObject to the `requiredKey` field in the Door script.

### Step 4: Displaying Key Count

An additional script can be implemented to display the number of keys in the player's inventory on a UI element. This
script responds to the addition and removal events in the collection by updating a counter accordingly.

Here’s the code for the KeyCountDisplay script:

```csharp
using UnityEngine;
using TMPro;
using SODD.Collections;

public class KeyCountDisplay : MonoBehaviour
{
    public Collection<GameObject> playerInventory;
    public TMP_Text keyCountText;

    private void OnEnable()
    {
        playerInventory.OnItemAdded += UpdateKeyCount;
        playerInventory.OnItemRemoved += UpdateKeyCount;
        UpdateKeyCount();
    }

    private void OnDisable()
    {
        playerInventory.OnItemAdded -= UpdateKeyCount;
        playerInventory.OnItemRemoved -= UpdateKeyCount;
    }

    private void UpdateKeyCount()
    {
        keyCountText.text = playerInventory.Count.ToString();
    }
}
```

1. Attach the `KeyCountDisplay` script to a UI GameObject.
2. Assign the `PlayerInventory` collection to the `playerInventory` field in the `KeyCountDisplay` script.
3. Assign a `TMP_Text` component to the `keyCountText` field in the `KeyCountDisplay` script.

### Step 5: Testing the Setup

Now, let's test the setup to ensure everything works as expected.

1. Run the game in the Unity Editor.
2. When the player collides with a key, the key is added to the inventory, and the key count display updates.
3. When the player collides with a door, the script checks for the required key in the inventory and unlocks the door if
   the key is present.

### Conclusion

This example highlights the benefits of utilizing Scriptable Collections, as it demonstrates how different systems can
interact with and modify a shared collection in a manner that is both decoupled and efficient. The PlayerInventory
collection acts as a central repository for keys, allowing the Key, Door, and KeyCountDisplay scripts to interact with
it independently.