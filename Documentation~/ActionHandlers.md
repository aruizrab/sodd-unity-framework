# Input Action Handlers

## Concept

Input Action Handlers are a concept introduced with the objective to expand upon Hipple’s use of ScriptableObjects for
managing events and data. These ScriptableObjects are designed to monitor events initiated by an Input Action and, in
response, trigger Scriptable Events. This functionality bridges de gap between events occurring in Unity’s Input System
and the event system featured by the framework. Additionally, the capability to debug event invocations, a feature
previously defined in the Scriptable Event requirements, is extended to Input Action Handlers, enhancing the ability to
log input actions in runtime from the framework’s event system.

## How It Works

- **Creation**: Input Action Handlers are created as ScriptableObject assets. These assets define specific input
  actions, such as button presses or axis movements. Handlers can be created through:
    - **Create menu**: Right-click in the Project window, navigate to `Create > SODD > Input Action Handlers`, and
      select the desired handler type.
    - **SODD menu**: In the main menu, go to `Tools > SODD > Input Action Handlers`, and choose the desired handler type
      from the provided options.
- **Action Referencing**: Each handler references a specific input action defined in an Input Action asset. This binding allows the
  handler to listen for and respond to user inputs.
- **Event Invocation**: When an input action is performed, the handler invokes a corresponding event, notifying all
  registered listeners.

## Implementations in the Framework

The SODD Framework provides several implementations of Input Action Handlers to cover various input types and use cases.
Below is a table detailing the core handler types included in the framework:

| **Handler Type**              | **Description**                                 |
|-------------------------------|-------------------------------------------------|
| **BoolInputActionHandler**    | Handles input actions passing boolean data.     |
| **FloatInputActionHandler**   | Handles input actions passing float data.       |
| **Vector2InputActionHandler** | Handles input actions producing Vector2 values. |
| **Vector3InputActionHandler** | Handles input actions producing Vector3 values. |
| **VoidInputActionHandler**    | Handles input actions that do not pass data.    |

## Practical Example

Let's walk through a practical example involving player movement using a `Vector2InputActionHandler`.

### Step 1: Creating the Input Action

First, we need to create an InputAction asset and configure it with an action named "Move" that reads the 2D vector input from the left joystick of a gamepad.

1. Open the Input Actions asset.
2. Create a new action named "Move".
3. Bind the action to the 2D vector input from the left joystick of a gamepad.

### Step 2: Creating the Input Action Handler

Next, we create a `Vector2InputActionHandler` named "Move Action Handler" to manage the "Move" action in the previously configured InputAction asset.

1. Right-click in the Project window of Unity.
2. Navigate to `Create > SODD > Input Action Handlers > Vector2InputActionHandler`.
3. Name the newly created handler `Move Action Handler`.
4. Assign the "Move" action to the `Move Action Handler` in the Unity Inspector.

### Step 3: Creating the Scriptable Event

We need to create the respective Scriptable Event that will be triggered by the handler in response to the input action. For this case, we create a single `Vector2` Event named "On Player Move".

1. Right-click in the Project window of Unity.
2. Navigate to `Create > SODD > Events > Vector2 Event`.
3. Name the newly created event `On Player Move`.

### Step 4: Configuring the Input Action Handler

Configure the `Move Action Handler` to invoke the "On Player Move" event.

1. Select the `Move Action Handler` in the Project window.
2. In the Unity Inspector, assign the "On Player Move" event to the appropriate field in the handler.

### Step 5: Testing the Setup

Activate the debug option for the "On Player Move" event to verify the configuration.

1. Select the `On Player Move` event in the Project window.
2. Enable the debug option in the Unity Inspector.

Run Play Mode and move the left joystick on a connected gamepad. Observe the Unity Console for new entries indicating invocations of the event. This confirms that the Input Action Handler is functioning correctly.

### Step 6: Implementing Player Movement

With this configuration, a player script can listen for the "On Player Move" event, either directly or through Event Listeners, to execute the game logic required for moving the player. This approach ensures that the player movement logic is cleanly separated from the input reading logic, and can be easily adjusted or expanded upon, adhering to principles of modular and decoupled design.

### Conclusion

By following these steps, we have successfully set up a modular and decoupled system for managing player movement using Input Action Handlers. This setup allows for easy adjustments and expansions to the input handling and movement logic.
