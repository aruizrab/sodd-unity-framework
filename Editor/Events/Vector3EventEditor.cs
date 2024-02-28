using System.Numerics;
using SODD.Events;
using UnityEditor;

namespace SODD.Editor.Events
{
    [CustomEditor(typeof(Vector3Event))]
    public class Vector3EventEditor : EventEditor<Vector3>
    {
    }
}