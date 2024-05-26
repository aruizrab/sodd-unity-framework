using SODD.Editor.Utils;
using SODD.Repositories;
using UnityEditor;

namespace SODD.Editor.Repositories
{
    public static class InputIconRepositoryMenu
    {
        [MenuItem("Tools/" + Framework.Repositories.InputIconRepository)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<InputIconRepository>();
        }
    }
}