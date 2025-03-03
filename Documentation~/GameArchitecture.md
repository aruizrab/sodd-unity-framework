# Solution: Game Architecture with ScriptableObjects

Ryan Hipple's solution to common problems encountered in Unity game development revolves around the innovative use of
ScriptableObjects. By leveraging ScriptableObjects, developers can create a more modular, editable, and debuggable game
architecture. This approach addresses key issues such as rigid dependencies, inflexible systems, and debugging
challenges. Central to this methodology are three core principles of game engineering: modularity, editability, and
debuggability.

## The Three Principles of Game Engineering

### Modularity

The first principle, modularity, states that game systems should be designed as separate and interchangeable modules,
components, or units. Each module performs a distinct function and operates independently of the others. Modularity
offers several benefits:

- **Reduced Interdependencies**: By ensuring modules are self-contained, changes in one module have minimal impact on
  others, reducing the risk of a change causing a cascade of issues across the game.
- **Reusability**: Modular components can be reused across different parts of a game or even in different projects,
  saving development time and resources.
- **Flexible Design**: Modularity allows developers to assemble and reassemble components in various configurations,
  aiding in experimentation and innovation in game design.

### Editability

The second principle, editability, states that game systems and data should be easily modified without requiring
modifications to the source code. This principle is particularly important for enabling designers and other team members
to tweak game elements without needing programming expertise.

- **Data-Driven Design**: This approach involves separating data from the logic of the game, allowing non-programmers to
  edit data directly.
- **Inspector-Friendly Tools**: In Unity, making systems editable often involves leveraging the Inspector window to
  create user-friendly interfaces for modifying game data.
- **Runtime Changes**: Allowing changes to game data at runtime aids in rapid prototyping and balancing, as adjustments
  can be made while the game is running, and their effects immediately observed.

### Debuggability

The third principle, debuggability, advocates for the ease with which a game can be debugged or tested for errors. A
well-designed game architecture should facilitate easy identification and fixing of bugs.

- **Isolation of Issues**: Modular design helps in isolating bugs to specific components, making it easier to identify
  the source of a problem.
- **Readable and Traceable**: The system should be transparent enough so that the flow of data and events can be easily
  followed and understood by the developers.
- **Tools and Visualizations**: Implementing tools that visualize the game’s operations, such as showing event triggers
  or data changes in real-time, can significantly aid in debugging.

## Replacing Singletons

### Modularizing Data with ScriptableObjects

One of the primary issues with Singletons is their tendency to create rigid and tightly coupled systems. Hipple's
approach involves using ScriptableObjects to modularize data, eliminating the need for Singletons. ScriptableObjects
allow data to be shared across multiple systems without creating direct dependencies. For instance, instead of a
Singleton managing player health, a ScriptableObject can store the health data. This data can then be referenced by any
system that needs it, such as the UI or enemy AI, without creating tight couplings.

### Runtime Sets

To manage lists of objects dynamically, Hipple introduces the concept of Runtime Sets. A Runtime Set is a
ScriptableObject that maintains a list of objects at runtime. Objects can register themselves with these sets when they
are instantiated and deregister when they are destroyed. This approach eliminates the need for Singleton managers to
keep track of objects, thereby reducing dependency issues and race conditions. For example, an EnemyRuntimeSet can track
all active enemies in the game, making it easy for various systems to access the list without relying on a Singleton.

### Dependency Injection Principles

Hipple emphasizes the use of dependency injection principles to further decouple systems. In Unity, this can be achieved
through the inspector, which acts as a dependency injector. Components can be assigned their dependencies via the
inspector, reducing the need for hard-coded references and enabling easy substitution of different implementations. This
method enhances modularity and makes testing and extending systems simpler.

## Enhancing Event Systems

Unity’s built-in event system (UnityEvent) has several limitations, such as rigid bindings and performance overheads due
to garbage collection. Hipple suggests creating a custom event system using ScriptableObjects. In this system,
ScriptableObjects represent events, and listeners register with these events to receive notifications. This decouples
event producers from consumers, allowing for more flexible and maintainable event handling. New listeners can be added
or removed without modifying the event source, and events can be raised without knowing which objects will respond.

## Replacing Enums

Hipple suggests using Scriptable Objects to represent enumerated types instead of traditional enums. Each possible value
is a Scriptable Object, which can hold additional data and behavior, allowing for dynamic modification of the set of
values.
For example, instead of using an enum for different weapon types (e.g., Sword, Bow, Magic), create a Scriptable Object
for each weapon type. These Scriptable Objects can contain additional data like damage values, range, and special
effects. This approach allows for adding new weapons without changing the codebase and avoids serialization issues.

## Improving Scene Management

To ensure that each scene loads as a clean slate, Hipple advocates minimizing the use of `DontDestroyOnLoad` objects.
Instead, persistent data should be managed through ScriptableObjects. This approach prevents unwanted data from carrying
over between scenes and ensures that each scene starts with a controlled and predictable state. By using
ScriptableObjects to manage persistent data, developers can maintain a modular and flexible scene structure.

## Debugging Enhancements

Hipple highlights the importance of integrating debugging tools into the Unity Inspector. By exposing runtime states and
allowing events to be raised directly from the Inspector, developers can diagnose and fix issues more efficiently. This
method makes debugging more intuitive and less time-consuming, providing immediate feedback on the game's state and
interactions.

## Data-Driven Design

Hipple’s approach strongly favors data-driven design, where game systems are configured through data rather than
hard-coded logic. ScriptableObjects play a central role in this design philosophy by storing configurations, variables,
and references. This method allows for more flexible and dynamic game behavior, as changes can be made through data
adjustments without altering the underlying code.

## Single Responsibility Principle

Adhering to the single responsibility principle is crucial in Hipple’s architecture. Each component or system in the
game should have a well-defined responsibility. This principle makes the system more modular, easier to manage, and
simpler to extend. Components can be developed, tested, and debugged in isolation, reducing overall system complexity.
