using DonutLab.SkinData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DonutLab.UI.Skins
{
    public class CustomisationPanelMenu : MonoBehaviour
    {
        public event Action<SkinGroup> GroupClicked;

        [SerializeField] private SkinGroupButton _tabButtonPrefab;
        [SerializeField] private float _spacing = 125f;

        private Dictionary<SkinGroup, SkinGroupButton> _buttons = new Dictionary<SkinGroup, SkinGroupButton>();

        private RectTransform Transform => transform as RectTransform;

        private void OnEnable()
        {
            foreach (SkinGroupButton button in _buttons.Values)
            {
                button.Clicked += OnButtonClickedHandler;
            }
        }

        private void OnDisable()
        {
            foreach (SkinGroupButton button in _buttons.Values)
            {
                button.Clicked -= OnButtonClickedHandler;
            }
        }

        public void Init(List<SkinGroup> groups)
        {
            for (int i = 0; i < groups.Count; i++)
            {
                CreateGroupButton(groups[i], i);
            }
        }

        private void CreateGroupButton(SkinGroup group, int idx)
        {
            var button = Instantiate(_tabButtonPrefab, Transform);
            var rectTransform = button.transform as RectTransform;

            rectTransform.anchoredPosition += Vector2.down * _spacing * idx;

            button.SetGroup(group);
            button.Clicked += OnButtonClickedHandler;
            _buttons.Add(group, button);
        }

        private void OnButtonClickedHandler(SkinGroup group)
        {
            GroupClicked?.Invoke(group);
        }
    }
}