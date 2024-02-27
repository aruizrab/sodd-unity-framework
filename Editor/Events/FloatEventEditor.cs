using SODD.Events;
using UnityEditor;

namespace SODD.Editor.Events
{
    [CustomEditor(typeof(FloatEvent))]
    public class FloatEventEditor : EventEditor<float>
    {
    }
}