using SODD.Editor.Utils;
using SODD.Repositories;
using UnityEditor;

namespace SODD.Editor.Repositories
{
    public static class VariableRepositoryMenu
    {
        [MenuItem("Tools/" + Framework.Repositories.VariableRepository)]
        public static void Create(MenuCommand command)
        {
            EditorHelper.CreateScriptableObject<VariableRepository>();
        }
    }
}