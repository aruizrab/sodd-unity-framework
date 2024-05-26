using System.Linq;
using SODD.Data;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SODD.Repositories
{
    [CreateAssetMenu(menuName = Framework.Repositories.InputIconRepository, fileName = nameof(InputIconRepository))]
    public class InputIconRepository : ScriptableObject
    {
        [SerializeField] private Sprite defaultIcon;
        [SerializeField] private SerializableDictionary<InputAction, Sprite> iconMap;

        public Sprite GetIcon(string path)
        {
            foreach (var pair in from pair in iconMap
                     let bindings = pair.Key.bindings
                     where bindings.Any(binding => binding.path.Equals(path))
                     select pair)
                return pair.Value;

            return defaultIcon;
        }
    }
}