using DonutLab.SkinData;
using UnityEngine;
using UnityEngine.UI;

namespace DonutLab.UI.Skins
{
    [RequireComponent(typeof(Button))]
    public class SkinPreviewElement : MonoBehaviour
    {
        [SerializeField] private Image _previewImage;
        [SerializeField] private GameObject _lockedIcon;
        [SerializeField] private GameObject _savedIcon;
        [SerializeField] private GameObject _selectedBorder;

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
            SetIsLocked(skinData.IsLocked);
        }

        private void SetIsLocked(bool isLocked)
        {
            _lockedIcon.gameObject.SetActive(isLocked);
        }

        private void SetIsSelected(bool isSelected)
        {
            _selectedBorder.SetActive(isSelected);
        }

        private void SetIsSaved(bool isSaved)
        {
            _savedIcon.SetActive(isSaved);
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
