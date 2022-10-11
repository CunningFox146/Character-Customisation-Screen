using DonutLab.SkinData;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace DonutLab.UI.Skins
{
    [RequireComponent(typeof(Button))]
    public class SkinGroupButton : MonoBehaviour
    {
        public event Action<SkinGroup> Clicked;

        [SerializeField] private Image _groupImage;
        private Button _button;
        private SkinGroup _group;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClickedHandler);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClickedHandler);
        }

        public void SetGroup(SkinGroup group)
        {
            _group = group;
            _groupImage.sprite = group.ButtonIcon;
        }

        private void OnButtonClickedHandler()
        {
            Clicked?.Invoke(_group);
        }
    }
}
