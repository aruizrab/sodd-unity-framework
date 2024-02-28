using SODD.Events;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Events
{
    [CustomEditor(typeof(Vector2Event))]
    public class Vector2EventEditor : EventEditor<Vector2>
    {
    }
}