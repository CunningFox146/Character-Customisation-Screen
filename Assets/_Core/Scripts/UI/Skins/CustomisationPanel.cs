using DonutLab.SkinData;
using Spine;
using TMPro;
using UnityEngine;

namespace DonutLab.UI.Skins
{
    public class CustomisationPanel : MonoBehaviour
    {
        public static CustomisationPanel Instance { get; private set; }

        [SerializeField] private CustomisationPanelMenu _menu;
        [SerializeField] private TMP_Text _groupName;
        [SerializeField] private SkinsGrid _skinsGrid;
        [SerializeField] private CharacterPreview _preview;

        private SkinSystem _skinSystem;

        public CharacterPreview CharacterPreview => _preview;

        private void Start()
        {
            UpdateGroup(_skinSystem.CurrentGroup);
            OnSelectedItemChanged(_skinSystem.CurrentGroup.GroupType, _skinSystem.GetSelectedItem());
            _menu.Init(_skinSystem.Groups);
        }

        private void OnEnable()
        {
            _skinSystem = SkinSystem.Instance;
            RegisterEventListeners();
        }

        private void OnDisable()
        {
            UnregisterEventListeners();
        }

        public void SetCurrentCharacterSkin(CharacterSkinData characterSkinData)
        {
            _preview.SetCharacterPreview(characterSkinData.Skin);
        }

        public void SetCurrentStandSkin(StandSkinData standSkinData)
        {
            _preview.SetStandPreview(standSkinData.GameSprite);
        }

        public void SetSelectedAsSaved()
        {
            _skinSystem.SetSelectedAsSave();
        }

        private void OnGroupClickedHandler(SkinGroup group)
        {
            _skinSystem.CurrentGroup = group;
        }

        private void OnCurrentGroupChangedHandler()
        {
            var group = _skinSystem.CurrentGroup;
            UpdateGroup(group);
        }

        private void UpdateGroup(SkinGroup group)
        {
            _skinsGrid.SetSource(group);
            _groupName.text = group.GroupName;
            _preview.SetSkinName(_skinSystem.GetSelectedItem().SkinName);
        }

        private void OnSavedItemChanged(SkinGroupType group, SkinDataBase skin)
        {

        }

        private void OnSelectedItemChanged(SkinGroupType group, SkinDataBase skin)
        {
            _preview.SetSkinName(skin.SkinName);
            switch (group)
            {
                case SkinGroupType.Character:
                    SetCurrentCharacterSkin(skin as CharacterSkinData);
                    break;
                case SkinGroupType.Stand:
                    SetCurrentStandSkin(skin as StandSkinData);
                    break;
                default:
                    break;
            }
        }

        private void RegisterEventListeners()
        {
            _skinSystem.SelectedItemChanged += OnSelectedItemChanged;
            _skinSystem.SavedItemChanged += OnSavedItemChanged;
            _skinSystem.CurrentGroupChanged += OnCurrentGroupChangedHandler;
            _menu.GroupClicked += OnGroupClickedHandler;
        }

        private void UnregisterEventListeners()
        {
            _skinSystem.SelectedItemChanged -= OnSelectedItemChanged;
            _skinSystem.SavedItemChanged -= OnSavedItemChanged;
            _skinSystem.CurrentGroupChanged -= OnCurrentGroupChangedHandler;
            _menu.GroupClicked -= OnGroupClickedHandler;
        }

    }
}
