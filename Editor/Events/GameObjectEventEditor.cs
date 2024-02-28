using SODD.Events;
using UnityEditor;
using UnityEngine;

namespace SODD.Editor.Events
{
    [CustomEditor(typeof(GameObjectEvent))]
    public class GameObjectEventEditor : EventEditor<GameObject>
    {
    }
}