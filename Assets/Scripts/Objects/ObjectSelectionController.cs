using System;
using Configs;
using UnityEngine;

namespace Objects
{
    public class ObjectSelectionController : MonoBehaviour
    {
        public event Action<ObjectConfig> OnObjectSelected;
        [SerializeField] private ObjectConfig _config;
        private GameObject _current;

        public ObjectConfig CurrentConfig => _config;

        public void Select(ObjectConfig config, GameObject obj)
        {
            _config = config;
            _current = obj;
            OnObjectSelected?.Invoke(config);
        }
    }
}