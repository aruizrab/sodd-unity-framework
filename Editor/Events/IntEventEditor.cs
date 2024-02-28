using SODD.Events;
using UnityEditor;

namespace SODD.Editor.Events
{
    [CustomEditor(typeof(IntEvent))]
    public class IntEventEditor : EventEditor<int>
    {
    }
}