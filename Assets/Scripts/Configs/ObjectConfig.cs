using Infrastructure.SO;
using UnityEngine;

namespace Configs
{
    public class ObjectConfig : ScriptableObjectIdentity
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private string _characteristics;
        [SerializeField] private GameObject _prefab;

        public string Name => _name;
        public string Description => _description;
        public string Characteristics => _characteristics;
        public GameObject Prefab => _prefab;
    }
}