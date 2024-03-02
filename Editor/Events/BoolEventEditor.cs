using SODD.Events;
using UnityEditor;

namespace SODD.Editor.Events
{
    [CustomEditor(typeof(BoolEvent))]
    public class BoolEventEditor : EventEditor<bool>
    {
    }
}