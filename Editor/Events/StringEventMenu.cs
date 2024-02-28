﻿using SODD.Editor.Utils;
using SODD.Events;
using UnityEditor;

namespace SODD.Editor.Events
{
    public static class StringEventMenu
    {
        [MenuItem("Tools/" + Framework.Events.String, priority = Framework.MenuOrders.String)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<StringEvent>();
        }
    }
}