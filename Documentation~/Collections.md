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

| **Collection Type** | **Description**                                    |
|---------------------|----------------------------------------------------|
| **GameObject Set**  | A collection that holds references to GameObjects. |
| **Transform Set**   | A collection that holds references to Transforms.  |
| **String Set**      | A collection that holds a set of strings.          |
| **Int Set**         | A collection that holds a set of integers.         |
| **Float Set**       | A collection that holds a set of floats.           |
| **Vector2 Set**     | A collection that holds a set of Vector2s.         |
| **Vector3 Set**     | A collection that holds a set of Vector3s.         |
