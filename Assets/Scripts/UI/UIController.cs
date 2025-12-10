using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Configs;
using Objects;
using TMPro;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Button _descriptionButton;
        [SerializeField] private Button _characteristicsButton;
        [SerializeField] private TextMeshProUGUI _infoText;
        [SerializeField] private GameObject _selectView;

        private ObjectSelectionController _selection;
        private ObjectsFactory _factory;

        private GameObject _createdObject;

        [Inject]
        private void Construct(ObjectSelectionController selection, ObjectsFactory factory)
        {
            _selection = selection;
            _factory = factory;

            _descriptionButton.interactable = false;
            _characteristicsButton.interactable = false;

            _selection.OnObjectSelected += HandleSelectionChanged;

            _descriptionButton.onClick.AddListener(ShowDescription);
            _characteristicsButton.onClick.AddListener(ShowCharacteristics);
        }

        private void HandleSelectionChanged(ObjectConfig config)
        {
            _descriptionButton.interactable = true;
            _characteristicsButton.interactable = true;
            
            _selectView?.gameObject.SetActive(true);
            _infoText.text = config.Description;

        }

        private void ShowDescription()
        {
            _selectView?.gameObject.SetActive(true);
            _infoText.text = _selection.CurrentConfig.Description;
        }

        private void ShowCharacteristics()
        {
            _selectView?.gameObject.SetActive(true);
            _infoText.text = _selection.CurrentConfig.Characteristics;
        }

        public void AddObject(ObjectConfig config)
        {
            if (_createdObject != null)
            {
                Destroy(_createdObject);
            }

            _createdObject = _factory.Create(config);
            _selection.Select(config, _createdObject);
        }
    }
}