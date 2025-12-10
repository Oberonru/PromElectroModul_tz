using Configs;
using UnityEngine;
using Zenject;

namespace Objects
{
    public class ObjectsFactory
    {
        [Inject] private DiContainer _di;
        
        public GameObject Create(ObjectConfig config, Transform parent = null)
        {
            return _di.InstantiatePrefab(config.Prefab, parent);
        }
    }
}