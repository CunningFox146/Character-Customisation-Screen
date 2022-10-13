using DonutLab.SkinData;
using TMPro;
using UnityEngine;

namespace DonutLab.UI.Skins
{
    public class CustomisationPanel : MonoBehaviour
    {
        [SerializeField] private CustomisationPanelMenu _menu;
        [SerializeField] private TMP_Text _groupName;
        [SerializeField] private SkinsGrid _skinsGrid;
        [SerializeField] private CharacterPreview _preview;

        private SkinSystem _skinSystem;

        public CharacterPreview CharacterPreview => _preview;

        private void Start()
        {
            UpdateGroup(_skinSystem.CurrentGroup);
            ApplyCurrentSkins();

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

        private void ApplyCurrentSkins()
        {
            for (int i = _skinSystem.Groups.Count - 1; i >= 0; i--)
            {
                var group = _skinSystem.Groups[i];
                ApplyItem(group.GroupType, _skinSystem.GetSelectedItem(group.GroupType));
            }
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
            UpdatePreview(_skinSystem.GetSelectedItem());
        }

        private void OnSavedItemChanged(SkinGroupType group, SkinDataBase skin)
        {

        }

        private void ApplyItem(SkinGroupType group, SkinDataBase skin)
        {
            if (skin == null) return;

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
            UpdatePreview(skin);
        }

        private void UpdatePreview(SkinDataBase skin)
        {
            _preview.SetSkinName(skin.SkinName);
            _preview.SetIsSaved(_skinSystem.GetSavedItem() == skin);
            _preview.SetIsLocked(skin.IsLocked);
        }

        private void OnSelectButtonClicked()
        {
            _skinSystem.SetSelectedAsSaved();
        }

        private void RegisterEventListeners()
        {
            _skinSystem.SelectedItemChanged += ApplyItem;
            _skinSystem.SavedItemChanged += OnSavedItemChanged;
            _skinSystem.CurrentGroupChanged += OnCurrentGroupChangedHandler;
            _menu.GroupClicked += OnGroupClickedHandler;
            _preview.SelectButtonClicked += OnSelectButtonClicked;
        }

        private void UnregisterEventListeners()
        {
            _skinSystem.SelectedItemChanged -= ApplyItem;
            _skinSystem.SavedItemChanged -= OnSavedItemChanged;
            _skinSystem.CurrentGroupChanged -= OnCurrentGroupChangedHandler;
            _menu.GroupClicked -= OnGroupClickedHandler;
            _preview.SelectButtonClicked -= OnSelectButtonClicked;
        }
    }
}
