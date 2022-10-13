using DonutLab.SkinData;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DonutLab.UI.Skins
{
    public class CustomisationPanel : MonoBehaviour
    {
        public static CustomisationPanel Instance { get; private set; }

        [SerializeField] private List<SkinGroup> _groups;
        [SerializeField] private CustomisationPanelMenu _menu;
        [SerializeField] private TMP_Text _groupName;
        [SerializeField] private SkinsGrid _skinsGrid;
        [SerializeField] private CharacterPreview _preview;

        private SkinGroup _currentGroup;
        public SkinGroup CurrentGroup
        {
            get => _currentGroup;
            set
            {
                if (_currentGroup == value) return;
                _currentGroup = value;
                _skinsGrid.SetSource(_currentGroup);
                _groupName.text = _currentGroup.GroupName;
            }
        }

        public CharacterPreview CharacterPreview => _preview;

        private void Awake()
        {
            Instance = this;
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

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        private void OnGroupClickedHandler(SkinGroup group)
        {
            CurrentGroup = group;
        }
    }
}
