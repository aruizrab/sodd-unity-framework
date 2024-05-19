# Scriptable Variables

<details>
<summary>Table of Contents</summary>

- [Concept](#concept)
- [How It Works](#how-it-works)
- [Implementations in the Framework](#implementations-in-the-framework)
- [Practical Example](#practical-example)

</details>

## Concept

A Scriptable Variable consists in a Scriptable Object that encapsulates a single value of a specific data type, such as
integers, floats or strings. These modular data containers can then be shared and referenced across
diverse systems within the game without said systems depending and relying on each other to retrieve and modify the game
state, reducing direct dependencies and enhancing flexibility.

Additionally, the values of Scriptable Variables are exposed in the Inspector, allowing to see and manipulate them
easily. This empowers both developers and designers, particularly those without extensive programming backgrounds, to
easily modify game parameters.

In practical terms, Scriptable Variables can be used to store any value, such as game configuration, player settings,
game state, etc.

![img.png](img.png)

## How It Works

- **Variable Creation**: Scriptable Variables are created as ScriptableObject assets. These assets are designed to hold
  specific data types, such as integers, floats, strings, booleans, etc. There are two ways to create these variables:
    - From the **Create menu**: Right-click in the Project window, navigate to `Create > SODD > Variables`, and select
      the
      desired event type (e.g., `IntVariable`).
    - From the **SODD menu**: In the main menu, go to `Tools > SODD > Varaibles`, and choose the desired variable type
      from
      the provided options.
- **Data Access and Modification**: Components can reference these variables to get or set their values. If a component
  modifies a value, other components referencing the same variable will see the changes when reading the value.
- **Value Observers**: Components can register as listeners for value changes in Scriptable Variables. This allows for
  automatic updates when the variable's value changes, promoting a reactive architecture.
- **Value Change Debugging**: Scriptable Variables have a built-in debug option that logs value changes to the console.
- **Inspector Integration**: Values of Scriptable Variables can be viewed and modified directly in the Unity Inspector,
  making it easier to debug and test changes during development.
- **Persistence**: Scriptable Variables can maintain their values across different scenes and play sessions, supporting
  persistent game states and smoother development workflows.

> [!NOTE]  
> In the Unity Editor, the values of Scriptable Variables (like any other ScriptableObject implementation) are persisted
> across play sessions. However, in the final build, these values are reset to their original state
> when the game is closed. **To ensure the persistence of Scriptable Variable values across play sessions in the final
> build, use the [VariableRepository]().**

## Implementations in the Framework

The SODD Framework offers several implementations of Scriptable Variables to cover various data types and use cases.
Below is a table detailing the core variable types included in the framework:

| **Variable Type**       | **Description**                                       |
|-------------------------|-------------------------------------------------------|
| **Int Variable**        | A ScriptableObject that holds an integer value.       |
| **Float Variable**      | A ScriptableObject that holds a float value.          |
| **String Variable**     | A ScriptableObject that holds a string value.         |
| **Bool Variable**       | A ScriptableObject that holds a boolean value.        |
| **Vector2 Variable**    | A ScriptableObject that holds a 2D vector value.      |
| **Vector3 Variable**    | A ScriptableObject that holds a 3D vector value.      |
| **GameObject Variable** | A ScriptableObject that holds a GameObject reference. |
| **LayerMask Variable**  | A ScriptableObject that holds a LayerMask value.      |

## Practical Example

Let's walk through a practical example of managing a player's health using a `FloatVariable`.

### Step 1: Creating the Scriptable Variable

First, we need to create a Scriptable Variable that will store the player's health.

1. Right-click in the Project window of Unity.
2. Navigate to `Create > SODD > Variables > Float`.
3. Name the newly created event `PlayerHealth`.

This Scriptable Variable will now hold the player's health value and can be accessed by various game components.

### Step 2: Creating the Health Manager Script

Next, we'll create a script that handles increasing and decreasing the player's health when the player takes damage or
heals. This script will reference the `PlayerHealth` variable directly.

Here’s the code for the `PlayerHealthManager` script:

```csharp
using UnityEngine;
using SODD.Variables;

public class PlayerHealthManager : MonoBehaviour
{
    public Variable<float> playerHealth; // Reference to the Scriptable Variable

    public void TakeDamage(float damage)
    {
        playerHealth.Value -= damage; // Decrease the player's health
    }

    public void Heal(float amount)
    {
        playerHealth.Value += amount; // Increase the player's health
    }
}
```

Once the script is created:

1. Create a new GameObject in the scene (e.g., `Player`).
2. Attach the new `PlayerHealthManager` script to this GameObject.
3. Add the reference to the `PlayerHealth` Scriptable Variable in the `PlayerHealthManager` script.

### Step 3: Creating the Health Display Script

We will create another script dedicated to displaying the health value on the screen. This script will also reference
the `PlayerHealth` variable but will not interact directly with the health management logic.

Here’s the code for the `HealthDisplay ` script:

```csharp
using UnityEngine;
using TMPro;
using SODD.Variables;

public class HealthDisplay : MonoBehaviour
{
    public Variable<float> playerHealth; // Reference to the Scriptable Variable
    public TMP_Text healthText; // Reference to the UI text component that displays the health

    private void OnEnable()
    {
        playerHealth.AddListener(UpdateHealthDisplay); // Subscribe to value changes
        UpdateHealthDisplay(playerHealth.Value); // Initialize the health display with the current health value
    }

    private void OnDisable()
    {
        playerHealth.RemoveListener(UpdateHealthDisplay); // Unsubscribe from value changes
    }

    private void UpdateHealthDisplay(float value)
    {
        healthText.text = value.ToString(); // Update the health display text
    }
}
```

1. Create a new GameObject in the scene (e.g., `UI`).
2. Attach the new `HealthDisplay` script.
3. Add the reference to the `PlayerHealth` scriptable event in the `HealthDisplay` script.

### Step 4: Triggering Health Changes

We need a way to trigger changes to the player's health. For this example, let's assume the player can take damage from
enemies and heal by collecting health packs.

> [!NOTE]  
> We are using the new [Send]() method provided by the SODD framework to trigger health changes.

Here’s the code for the DamageDealer script:

```csharp
using UnityEngine;
using SODD.Core;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 10f; // Amount of damage to deal

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if the collider belongs to the player
        {
            collision.gameObject.Send<PlayerHealthManager>(manager => manager.TakeDamage(damageAmount)); // Use Send method to deal damage to the player
        }
    }
}
```

Here’s the code for the HealthPack script:

```csharp
using UnityEngine;
using SODD.Core;

public class HealthPack : MonoBehaviour
{
    public float healAmount = 20f; // Amount of health to restore

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Check if the collider belongs to the player
        {
            collision.gameObject.Send<PlayerHealthManager>(manager => manager.Heal(healAmount)); // Use Send method to heal the player
            Destroy(gameObject); // Destroy the health pack
        }
    }
}
```

### Step 6: Testing the Setup

Now, let's test the setup to ensure everything works as expected.

1. Run the game in the Unity Editor.
2. When the player collides with a DamageDealer, the PlayerHealth value decreases.
3. When the player collides with a HealthPack, the PlayerHealth value increases.
4. Observe the health value updating in the UI as the player takes damage or collects health packs.
5. Modify the health value directly in the Inspector during play mode to test the dynamic updating of the health
   display.

### Conclusion

By using Scriptable Variables, we have successfully decoupled health management from health display, ensuring that
the `PlayerHealthManager` handles health changes while the `HealthDisplay` script updates the UI independently.
This decoupling enhances modularity, allowing each script to be modified, replaced, or reused without impacting others.
New game logic regarding player health, such as effects when taking damage or healing, or restarting the level when
health decreases to zero, can be added by creating new scripts that reference the variable without modifying existing
scripts.