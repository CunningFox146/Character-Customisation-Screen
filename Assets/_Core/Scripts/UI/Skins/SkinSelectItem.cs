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
        [SerializeField] private CharacterPreview _preview;
        private Button _button;
        private ISkinData _skinData;

        public string Id { get; private set; }

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _preview = CustomisationPanel.Instance.CharacterPreview;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClickedHandler);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClickedHandler);
        }

        public virtual void SetData(ISkinData skinData)
        {
            _skinData = skinData;
            _previewImage.sprite = _skinData.Preview;
            Id = _skinData.SkinId;
        }

        private void OnButtonClickedHandler()
        {
            _skinData.ApplyToPreview(_preview);
        }
    }
}
