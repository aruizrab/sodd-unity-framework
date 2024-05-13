using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("com.github.aruizrab.sodd-unity-framework.Editor")]

namespace SODD
{
    internal static class Framework
    {
        public const string Root = "SODD/";

        public static class DataTypes
        {
            public const string Void = "Void";

            // Primitive types
            public const string Bool = "Bool";
            public const string Float = "Float";
            public const string Int = "Int";
            public const string String = "String";

            public const string Enum = "Enum";

            // Data structures
            public const string List = "List";

            public const string Dictionary = "Dictionary";

            // Unity data types
            public const string Vector2 = "Vector2";
            public const string Vector3 = "Vector3";
            public const string Color = "Color";
            public const string LayerMask = "LayerMask";

            public const string AudioClip = "Audio Clip";

            // Unity reference types
            public const string GameObject = "GameObject";
            public const string ScriptableObject = "ScriptableObject";
            public const string Component = "Component";
            public const string Object = "Object";
        }

        public static class MenuOrders
        {
            public const int Void = 0;
            public const int Bool = 11;
            public const int Int = 12;
            public const int Float = 13;
            public const int String = 14;
            public const int Enum = 31;
            public const int Vector2 = 32;
            public const int Vector3 = 33;
            public const int List = 34;
            public const int Dictionary = 35;
            public const int Color = 51;
            public const int LayerMask = 52;
            public const int AudioClip = 53;
            public const int GameObject = 71;
            public const int ScriptableObject = 72;
            public const int Component = 73;
            public const int Object = 74;
        }

        public static class Events
        {
            public const string Path = Root + "Events/";

            public const string Void = Path + DataTypes.Void;
            public const string Bool = Path + DataTypes.Bool;
            public const string Float = Path + DataTypes.Float;
            public const string Int = Path + DataTypes.Int;
            public const string String = Path + DataTypes.String;
            public const string Enum = Path + DataTypes.Enum;
            public const string List = Path + DataTypes.List;
            public const string Dictionary = Path + DataTypes.Dictionary;
            public const string Vector2 = Path + DataTypes.Vector2;
            public const string Vector3 = Path + DataTypes.Vector3;
            public const string Color = Path + DataTypes.Color;
            public const string LayerMask = Path + DataTypes.LayerMask;
            public const string AudioClip = Path + DataTypes.AudioClip;
            public const string GameObject = Path + DataTypes.GameObject;
            public const string ScriptableObject = Path + DataTypes.ScriptableObject;
            public const string Component = Path + DataTypes.Component;
            public const string Object = Path + DataTypes.Object;
        }
        
        public static class EventListeners
        {
            public const string Name = "Event Listener";
            public const string Path = Root + "Event Listeners/";
            
            public const string Void = Path + DataTypes.Void;
            public const string Bool = Path + DataTypes.Bool;
            public const string Float = Path + DataTypes.Float;
            public const string Int = Path + DataTypes.Int;
            public const string String = Path + DataTypes.String;
            public const string Enum = Path + DataTypes.Enum;
            public const string List = Path + DataTypes.List;
            public const string Dictionary = Path + DataTypes.Dictionary;
            public const string Vector2 = Path + DataTypes.Vector2;
            public const string Vector3 = Path + DataTypes.Vector3;
            public const string Color = Path + DataTypes.Color;
            public const string LayerMask = Path + DataTypes.LayerMask;
            public const string AudioClip = Path + DataTypes.AudioClip;
            public const string GameObject = Path + DataTypes.GameObject;
            public const string ScriptableObject = Path + DataTypes.ScriptableObject;
            public const string Component = Path + DataTypes.Component;
            public const string Object = Path + DataTypes.Object;

            public const string VoidEventListener = Path + DataTypes.Void + Name;
            public const string BoolEventListener = Path + DataTypes.Bool + Name;
            public const string FloatEventListener = Path + DataTypes.Float + Name;
            public const string IntEventListener = Path + DataTypes.Int + Name;
            public const string StringEventListener = Path + DataTypes.String + Name;
            public const string EnumEventListener = Path + DataTypes.Enum + Name;
            public const string ListEventListener = Path + DataTypes.List + Name;
            public const string DictionaryEventListener = Path + DataTypes.Dictionary + Name;
            public const string Vector2EventListener = Path + DataTypes.Vector2 + Name;
            public const string Vector3EventListener = Path + DataTypes.Vector3 + Name;
            public const string ColorEventListener = Path + DataTypes.Color + Name;
            public const string LayerMaskEventListener = Path + DataTypes.LayerMask + Name;
            public const string AudioClipEventListener = Path + DataTypes.AudioClip + Name;
            public const string GameObjectEventListener = Path + DataTypes.GameObject + Name;
            public const string ComponentEventListener = Path + DataTypes.Component + Name;
            public const string ObjectEventListener = Path + DataTypes.Object + Name;
        }
        
        public static class Variables
        {
            public const string Path = Root + "Variables/";

            public const string Void = Path + DataTypes.Void;
            public const string Bool = Path + DataTypes.Bool;
            public const string Float = Path + DataTypes.Float;
            public const string Int = Path + DataTypes.Int;
            public const string String = Path + DataTypes.String;
            public const string Enum = Path + DataTypes.Enum;
            public const string List = Path + DataTypes.List;
            public const string Dictionary = Path + DataTypes.Dictionary;
            public const string Vector2 = Path + DataTypes.Vector2;
            public const string Vector3 = Path + DataTypes.Vector3;
            public const string Color = Path + DataTypes.Color;
            public const string LayerMask = Path + DataTypes.LayerMask;
            public const string AudioClip = Path + DataTypes.AudioClip;
            public const string GameObject = Path + DataTypes.GameObject;
            public const string ScriptableObject = Path + DataTypes.ScriptableObject;
            public const string Component = Path + DataTypes.Component;
            public const string Object = Path + DataTypes.Object;
        }
        
        public static class VariableObservers
        {
            public const string Name = "Variable Observer";
            public const string Path = Root + "Variable Observers/";
            
            public const string Void = Path + DataTypes.Void;
            public const string Bool = Path + DataTypes.Bool;
            public const string Float = Path + DataTypes.Float;
            public const string Int = Path + DataTypes.Int;
            public const string String = Path + DataTypes.String;
            public const string Enum = Path + DataTypes.Enum;
            public const string List = Path + DataTypes.List;
            public const string Dictionary = Path + DataTypes.Dictionary;
            public const string Vector2 = Path + DataTypes.Vector2;
            public const string Vector3 = Path + DataTypes.Vector3;
            public const string Color = Path + DataTypes.Color;
            public const string LayerMask = Path + DataTypes.LayerMask;
            public const string AudioClip = Path + DataTypes.AudioClip;
            public const string GameObject = Path + DataTypes.GameObject;
            public const string ScriptableObject = Path + DataTypes.ScriptableObject;
            public const string Component = Path + DataTypes.Component;
            public const string Object = Path + DataTypes.Object;

            public const string VoidVariableObserver = Path + DataTypes.Void + Name;
            public const string BoolVariableObserver = Path + DataTypes.Bool + Name;
            public const string FloatVariableObserver = Path + DataTypes.Float + Name;
            public const string IntVariableObserver = Path + DataTypes.Int + Name;
            public const string StringVariableObserver = Path + DataTypes.String + Name;
            public const string EnumVariableObserver = Path + DataTypes.Enum + Name;
            public const string ListVariableObserver = Path + DataTypes.List + Name;
            public const string DictionaryVariableObserver = Path + DataTypes.Dictionary + Name;
            public const string Vector2VariableObserver = Path + DataTypes.Vector2 + Name;
            public const string Vector3VariableObserver = Path + DataTypes.Vector3 + Name;
            public const string ColorVariableObserver = Path + DataTypes.Color + Name;
            public const string LayerMaskVariableObserver = Path + DataTypes.LayerMask + Name;
            public const string AudioClipVariableObserver = Path + DataTypes.AudioClip + Name;
            public const string GameObjectVariableObserver = Path + DataTypes.GameObject + Name;
            public const string ComponentVariableObserver = Path + DataTypes.Component + Name;
            public const string ObjectVariableObserver = Path + DataTypes.Object + Name;
        }
        
        public static class Collections
        {
            public const string Path = Root + "Collections/";

            public const string Void = Path + DataTypes.Void;
            public const string Bool = Path + DataTypes.Bool;
            public const string Float = Path + DataTypes.Float;
            public const string Int = Path + DataTypes.Int;
            public const string String = Path + DataTypes.String;
            public const string Enum = Path + DataTypes.Enum;
            public const string List = Path + DataTypes.List;
            public const string Dictionary = Path + DataTypes.Dictionary;
            public const string Vector2 = Path + DataTypes.Vector2;
            public const string Vector3 = Path + DataTypes.Vector3;
            public const string Color = Path + DataTypes.Color;
            public const string LayerMask = Path + DataTypes.LayerMask;
            public const string AudioClip = Path + DataTypes.AudioClip;
            public const string GameObject = Path + DataTypes.GameObject;
            public const string ScriptableObject = Path + DataTypes.ScriptableObject;
            public const string Component = Path + DataTypes.Component;
            public const string Object = Path + DataTypes.Object;
        }

        public static class Input
        {
            public const string Path = Root + "Input/";

            public static class ActionHandlers
            {
                public const string Path = Input.Path + "Action Handlers/";

                public const string Void = Path + DataTypes.Void;
                public const string Bool = Path + DataTypes.Bool;
                public const string Float = Path + DataTypes.Float;
                public const string Int = Path + DataTypes.Int;
                public const string Vector2 = Path + DataTypes.Vector2;
                public const string Vector3 = Path + DataTypes.Vector3;
            }
        }
    }
}