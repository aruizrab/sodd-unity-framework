using SODD.Collections;
using SODD.Editor.Utils;
using UnityEditor;

namespace SODD.Editor.Collections
{
    public static class AudioClipCollectionMenu
    {
        [MenuItem("Tools/" + Framework.Collections.AudioClip, priority = Framework.MenuOrders.AudioClip)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<AudioClipCollection>();
        }
    }
}