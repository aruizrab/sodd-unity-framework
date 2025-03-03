# Variable Observers

## Concept

Variable Observers are components designed to monitor changes in ScriptableObject variables and trigger UnityEvents in response. They provide a way to react to variable changes without tightly coupling the game logic to the variable implementation. This makes the architecture more modular and easier to maintain.

## How It Works

- **Observer Creation**: Variable Observers are MonoBehaviour components that can be added to GameObjects. They are configured to observe specific ScriptableObject variables and respond with UnityEvents.
- **Variable Binding**: Each observer is assigned a ScriptableObject variable to monitor. When the variable's value changes, the observer triggers the associated UnityEvent.
- **Inspector Integration**: Observers can be configured directly in the Unity Inspector, enabling quick setup and testing without writing additional code.
- **Event Invocation**: When the variable's value changes, the observer invokes the configured UnityEvent, passing the new value along to the registered methods.

## Implementations in the Framework

The SODD Framework provides several implementations of Variable Observers to handle different types of variables. Below is a table detailing the core observer types included in the framework:

| **Observer Type**           | **Description**                                                             |
|-----------------------------|-----------------------------------------------------------------------------|
| **BoolVariableObserver**    | Observes changes in boolean variables and triggers UnityEvents accordingly. |
| **FloatVariableObserver**   | Observes changes in float variables and triggers UnityEvents accordingly.   |
| **IntVariableObserver**     | Observes changes in integer variables and triggers UnityEvents accordingly. |
| **StringVariableObserver**  | Observes changes in string variables and triggers UnityEvents accordingly.  |
| **Vector2VariableObserver** | Observes changes in Vector2 variables and triggers UnityEvents accordingly. |
| **Vector3VariableObserver** | Observes changes in Vector3 variables and triggers UnityEvents accordingly. |

## Practical Example

This example expands upon the example stated earlier in the Scriptable Events section, consisting in the management of a player’s score.

### Step 1: Adding the Variable Observer

First, add an Int Variable Observer to the GameObject that holds the Score Manager component.

1. Select the GameObject with the Score Manager component in the Unity Editor.
2. Click `Add Component` and choose `IntVariableObserver`.

### Step 2: Configuring the Variable Observer

Next, assign the "Player Score" variable to the observer.

1. In the Unity Inspector, find the `IntVariableObserver` component.
2. Assign the "Player Score" variable to the observer.

### Step 3: Setting Up the Unity Event

Within the Unity Event section of the observer, configure the method to update the UI component when the variable changes.

1. In the `IntVariableObserver` component, find the `UnityEvent` section.
2. Click the `+` button to add a new listener.
3. Drag the UI component (e.g., a TextMeshProUGUI) into the `None (Object)` field.
4. Select the method responsible for updating the UI from the dropdown list.
5. Ensure the variable's value is passed dynamically.

### Step 4: Testing the Setup

Run Play Mode and observe the UI element displaying the Player Score. It should be initially set to the variable's value and update automatically whenever the variable's value changes.

### Conclusion

By using Variable Observers, the `PlayerScoreDisplay` script becomes redundant. The function to update the UI component is specified directly within the UnityEvent of the observer. This setup enhances the modularity and responsiveness of the game architecture, ensuring that UI elements and other components remain synchronized with the underlying data without requiring additional scripting effort.
