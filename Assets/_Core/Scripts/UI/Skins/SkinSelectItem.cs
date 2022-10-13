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
        [SerializeField] private SkinSystem _skinSystem;
        private Button _button;
        private SkinDataBase _skinData;

        public string Id { get; private set; }

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _skinSystem = SkinSystem.Instance;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClickedHandler);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClickedHandler);
        }

        public virtual void SetData(SkinDataBase skinData)
        {
            _skinData = skinData;
            _previewImage.sprite = _skinData.Preview;
            Id = _skinData.SkinId;
        }

        private void OnButtonClickedHandler()
        {
            _skinSystem.SetSelectedItem(_skinSystem.CurrentGroup.GroupType, _skinData);
        }
    }
}
