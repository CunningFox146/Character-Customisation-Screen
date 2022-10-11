using DonutLab.SkinData;
using System.Collections.Generic;
using UnityEngine;

namespace DonutLab.UI.Skins
{
    public class CustomisationPanel : MonoBehaviour
    {
        [SerializeField] private List<SkinGroup> _groups;
        [SerializeField] private CustomisationPanelMenu _menu;
        [SerializeField] private SkinsGrid _skinsGrid;

        private SkinGroup _currentGroup;
        public SkinGroup CurrentGroup
        {
            get => _currentGroup;
            set
            {
                if (_currentGroup == value) return;
                _currentGroup = value;
                _skinsGrid.SetSource(_currentGroup);
            }
        }

        private void Awake()
        {
            CurrentGroup = _groups[0];
            _menu.Init(_groups);
        }

        private void OnEnable()
        {
            _menu.GroupClicked += OnGroupClickedHandler;
        }

        private void OnDisable()
        {
            _menu.GroupClicked -= OnGroupClickedHandler;
        }

        private void OnGroupClickedHandler(SkinGroup group)
        {
            CurrentGroup = group;
        }
    }
}
