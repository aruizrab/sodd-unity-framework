using SODD.Core;
using SODD.Events;
using UnityEditor;

namespace SODD.Editor.Events
{
    [CustomEditor(typeof(VoidEvent))]
    public class VoidEventEditor : EventEditor<Void>
    {
    }
}