using DonutLab.SkinData;
using UnityEngine;
using UnityEngine.UI;

namespace DonutLab.UI.Skins
{
    [RequireComponent(typeof(Button))]
    public class SkinSelectItem : MonoBehaviour
    {
        [SerializeField] private Image _previewImage;
        [SerializeField] private Image _statusIcon;
        [SerializeField] private GameObject _selectedBorder;
        [Space]
        [SerializeField] private Sprite _savedImage;
        [SerializeField] private Sprite _lockedImage;

        private SkinSystem _skinSystem;
        private Button _button;
        private SkinDataBase _skinData;

        public string Id { get; private set; }

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _skinSystem = SkinSystem.Instance;
            RegisterEventHandlers();
        }

        private void OnDisable()
        {
            UnregisterEventHandlers();
        }

        public virtual void SetData(SkinDataBase skinData)
        {
            _skinData = skinData;
            _previewImage.sprite = _skinData.Preview;
            Id = _skinData.SkinId;

            SetIsSelected(_skinSystem.GetSelectedItem() == skinData);
            SetIsSaved(_skinSystem.GetSavedItem() == skinData);
        }

        private void SetIsSelected(bool isSelected)
        {
            _selectedBorder.SetActive(isSelected);
        }

        private void SetIsSaved(bool isSaved)
        {
            _statusIcon.sprite = isSaved ? _savedImage : _lockedImage;
        }

        private void RegisterEventHandlers()
        {
            _skinSystem.SavedItemChanged += OnSavedItemChanged;
            _skinSystem.SelectedItemChanged += OnSelectedItemChangedHandler;
            _button.onClick.AddListener(OnButtonClickedHandler);
        }

        private void UnregisterEventHandlers()
        {
            _button.onClick.RemoveListener(OnButtonClickedHandler);
        }

        private void OnSelectedItemChangedHandler(SkinGroupType _, SkinDataBase data)
        {
            SetIsSelected(data == _skinData);
        }

        private void OnSavedItemChanged(SkinGroupType _, SkinDataBase data)
        {
            SetIsSaved(data == _skinData);
        }

        private void OnButtonClickedHandler()
        {
            _skinSystem.SetSelectedItem(_skinSystem.CurrentGroup.GroupType, _skinData);
        }
    }
}
