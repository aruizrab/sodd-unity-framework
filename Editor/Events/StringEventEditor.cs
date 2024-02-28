using SODD.Events;
using UnityEditor;

namespace SODD.Editor.Events
{
    [CustomEditor(typeof(StringEvent))]
    public class StringEventEditor : EventEditor<string>
    {
    }
}