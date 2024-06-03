# Event Listeners

## Concept

Event Listeners are components designed to subscribe to a Scriptable Event. They provide a decoupled way to handle events, allowing game logic to be more modular and manageable. Event Listeners listen for specific events and invoke UnityEvents when those events are raised, making it easy to connect game logic directly through the Unity Editor.

This design might initially seem redundant, but it serves an important purpose in separating the responsibilities of Scriptable Events from UnityEvents. Scriptable Events function as a global broadcast mechanism, allowing any component across various scenes to subscribe and respond to the events. UnityEvents, on the other hand, are local to the components they are attached to, allowing for the definition of actions within a more constrained context, such as within the components of a GameObject or Prefab.
Moreover, given that the actions reacting to a Scriptable Event are created and modified from the Unity Event inspector, the need for changes in the code is removed when an alteration in behavior requirements occur.


## How It Works

- **Listener Creation**: Event Listeners are MonoBehaviour components that can be added to GameObjects, or through the `SODD Menu Tools > SODD > Event Listeners`.
- **Event Binding**: Each listener is assigned a Scriptable Event to listen to. When the event is raised, the listener triggers the associated UnityEvent.
- **Inspector Integration**: Listeners can be configured directly in the Unity Inspector, enabling quick setup and testing without writing additional code.
- **Event Invocation**: When an event is raised, the listener invokes the configured UnityEvent, passing any payload data along to the registered methods.

## Implementations in the Framework

The SODD Framework provides several implementations of Event Listeners to handle different types of payloads. Below is a table detailing the core listener types included in the framework:

| **Listener Type**           | **Description**                                 |
|-----------------------------|-------------------------------------------------|
| **BoolEventListener**       | Listens for events with a boolean payload.      |
| **FloatEventListener**      | Listens for events with a float payload.        |
| **GameObjectEventListener** | Listens for events with a GameObject payload.   |
| **IntEventListener**        | Listens for events with an integer payload.     |
| **StringEventListener**     | Listens for events with a string payload.       |
| **Vector2EventListener**    | Listens for events with a Vector2 payload.      |
| **Vector3EventListener**    | Listens for events with a Vector3 payload.      |
| **VoidEventListener**       | Listens for events with no payload.             |

## Practical Example

This practical example expands upon the example stated earlier in the Scriptable Events section, consisting in the management of a player’s score.

### Step 1: Adding the Event Listener

First, add an Int Event Listener to the GameObject that holds the Score Manager component.

1. Select the GameObject with the Score Manager component in the Unity Editor.
2. Click `Add Component` and choose `IntEventListener`.

### Step 2: Configuring the Event Listener

Next, assign the "Increment Player Score Event" to the listener.

1. In the Unity Inspector, find the `IntEventListener` component.
2. Assign the "Increment Player Score Event" to the listener.

### Step 3: Setting Up the Unity Event

Within the Unity Event section of the listener, configure the Score Manager's method responsible for incrementing the score to be called when the event is invoked.

1. In the `IntEventListener` component, find the `UnityEvent` section.
2. Click the `+` button to add a new listener.
3. Drag the Score Manager component into the `None (Object)` field.
4. Select the method responsible for incrementing the score from the dropdown list.
5. Ensure the event's payload is passed dynamically.

### Step 4: Testing the Setup

Activate the debug option for the "Increment Player Score Event" to verify the configuration.

1. Select the `Increment Player Score Event` in the Project window.
2. Enable the debug option in the Unity Inspector.

Run Play Mode and trigger the event to observe the Unity Console for entries indicating invocations of the event. This confirms that the Event Listener is functioning correctly.

### Conclusion

By using Event Listeners, the Score Manager is decoupled from the Int Event. The Score Manager no longer needs to directly reference the event or include logic for subscription and notification handling. This modular approach allows game designers to dictate game behaviors from the Unity Editor without modifying the underlying code, simplifying the Score Manager script and empowering designers to prototype, iterate, and define game behaviors with greater independence and efficiency.
