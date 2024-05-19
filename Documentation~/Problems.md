# Problem: Common Scripting Challenges in Unity

<details>
  <summary>Table of Contents</summary>

- [Singleton Problems](#singleton-problems)
    - [Rigid Connections](#rigid-connections)
    - [Loss of Polymorphism](#loss-of-polymorphism)
    - [Testing Difficulties](#testing-difficulties)
    - [Dependency Nightmares](#dependency-nightmares)
    - [Global State](#global-state)
    - [Single Instance Limitation](#single-instance-limitation)
- [Challenges with Traditional Event Systems](#challenges-with-traditional-event-systems)
    - [Unity Event Limitations](#unity-event-limitations)
    - [Hard References](#hard-references)
- [Issues with Enums](#issues-with-enums)
    - [Code-Driven](#code-driven)
    - [Difficult to Reorder or Remove](#difficult-to-reorder-or-remove)
    - [No Additional Data](#no-additional-data)
- [Scene Management Problems](#scene-management-problems)
    - [Transient Data Management](#transient-data-management)
    - [Clean Slate Scenes](#clean-slate-scenes)
    - [Debugging Issues](#debugging-issues)
- [General Architectural Challenges](#general-architectural-challenges)
    - [Maintaining Flexibility and Extensibility](#maintaining-flexibility-and-extensibility)
    - [Performance Overheads](#performance-overheads)
    - [Design and Code Separation](#design-and-code-separation)

</details>

## Singleton Problems

### Rigid Connections

One of the significant issues with Singletons in Unity is the creation of rigid connections between different systems.
When systems are tightly coupled, modifying or extending one part of the system necessitates changes in others, which
reduces flexibility and can introduce new bugs. This tight coupling means that components cannot easily be reused or
reconfigured without affecting other parts of the game, leading to a more fragile and less maintainable codebase.

### Loss of Polymorphism

Singletons undermine the object-oriented principle of polymorphism, which is the ability to substitute objects of
different types through a common interface. When a system relies on a single instance of a class (a Singleton), it
becomes difficult to replace that instance with a different implementation. This limitation makes it harder to create
variants of systems for testing or to provide alternative behaviors, thus reducing the overall flexibility of the
architecture.

### Testing Difficulties

The hidden dependencies introduced by Singletons pose significant challenges for unit testing. Since Singletons are
globally accessible and maintain state, tests can become interdependent, leading to flaky or unreliable tests. Isolating
a single component for testing is challenging when it depends on the global state maintained by Singletons, making it
harder to identify the source of a failure.

### Dependency Nightmares

As the number of Singletons in a project increases, managing the dependencies between them becomes increasingly complex.
This complexity often leads to race conditions, where the order of initialization and access to these Singletons can
cause unpredictable behavior. These dependency issues make the system more error-prone and harder to debug.

### Global State

Singletons typically maintain state across different scenes, which can lead to unintended side effects. For example, if
a Singleton retains data that should be reset between scenes, it can cause bugs that are difficult to track down. This
persistent state breaks the clean slate principle, where each scene should start with a known and controlled state.

### Single Instance Limitation

By design, a Singleton pattern limits the system to a single instance of a class. This restriction can become
problematic if the game's requirements evolve to support multiple instances of a system. For instance, a game might
initially have a single player, but later need to support multiple players or sessions. Revisiting and refactoring the
code to remove the Singleton limitation can be time-consuming and error-prone.

## Challenges with Traditional Event Systems

### Unity Event Limitations

Unity’s built-in event system, UnityEvent, has several limitations. It relies on serialized function calls, which means
the exact function to be called must be specified at design time. This approach is rigid and does not support dynamic
binding or more complex event handling scenarios. Furthermore, UnityEvent can introduce garbage collection issues due to
the way it resolves and invokes functions using reflection, which can impact performance, especially in
performance-critical applications like games.

### Hard References

UnityEvents create hard references between components, leading to maintenance difficulties and reduced modularity. Each
event binding is a direct link from the event source to the event handler, making it challenging to refactor or extend
the system. This tight coupling hinders the ability to decouple systems and create more modular and reusable components.

## Issues with Enums

### Code-Driven

Enums in Unity are defined in code, which makes them less flexible and harder to modify. Adding, removing, or reordering
enum values requires changes in the codebase and recompilation, which can be cumbersome and error-prone, especially in
large projects.

### Difficult to Reorder or Remove

When enums are serialized, their values are stored based on their index positions. Changing the order or removing enum
values can break the serialized data, causing runtime errors and inconsistencies. This limitation makes maintaining and
evolving the game’s data structures more challenging over time.

### No Additional Data

Enums cannot hold additional data, which limits their utility. Often, developers end up creating additional lookup
tables or data structures to associate more data with each enum value. This extra complexity adds overhead and increases
the risk of synchronization issues between the enum and the associated data.

## Scene Management Problems

### Transient Data Management

Managing transient data across scenes can be complex, particularly when using DontDestroyOnLoad objects. These objects
persist across scene loads, which can clutter the global namespace and lead to bugs due to unintended interactions
between persistent and transient data. Ensuring that only the necessary data persists while keeping the scene-specific
data isolated is a delicate balance.

### Clean Slate Scenes

Ensuring each scene loads as a clean slate is essential for maintaining modularity and flexibility. Persistent data or
objects that carry over from previous scenes can introduce hard-to-track bugs and unintended behavior. By adhering to
the clean slate principle, developers can ensure that each scene starts with a controlled and predictable state,
reducing the risk of unexpected interactions.

### Debugging Issues

Lack of Debugging Tools
Debugging complex interactions between components and systems can be difficult without proper tools and strategies. A
lack of built-in debugging support for custom architectures makes it challenging to diagnose issues. Ensuring that every
feature has a clear debugging strategy and providing tools to expose runtime state and interactions are crucial for
effective debugging.

## General Architectural Challenges

### Maintaining Flexibility and Extensibility

As games grow in complexity, maintaining an architecture that is both flexible and extensible becomes increasingly
challenging. The architecture must allow for easy addition of new features and modifications without extensive
refactoring. Achieving this balance requires careful planning and adherence to principles that promote modularity and
decoupling.

### Performance Overheads

Ensuring that architectural patterns do not introduce significant performance overheads is crucial, especially for
resource-constrained platforms like mobile devices and VR. While achieving a clean and maintainable architecture is
important, it should not come at the cost of runtime performance. Profiling and optimizing critical paths in the
architecture are essential to maintain performance.

### Design and Code Separation

Balancing the needs of designers and developers can be challenging. Designers require systems that are easy to use and
flexible, while developers need robust and maintainable code. Creating an architecture that allows designers to work
independently of developers, through data-driven and component-based systems, helps bridge this gap and improves
collaboration.