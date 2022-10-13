using DonutLab.Save;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DonutLab.SkinData
{
    public class SkinSystem : MonoBehaviour
    {
        public static SkinSystem Instance { get; private set; }

        public event Action CurrentGroupChanged;
        public event Action<SkinGroupType, SkinDataBase> SelectedItemChanged;
        public event Action<SkinGroupType, SkinDataBase> SavedItemChanged;

        [SerializeField] private SaveSystem _saveSystem;
        private SkinGroup _currentGroup;
        private Dictionary<SkinGroupType, SkinDataBase> _selectedItems;
        private Dictionary<SkinGroupType, SkinDataBase> _savedItems;

        [field: SerializeField] public List<SkinGroup> Groups { get; private set; }

        public SkinGroup CurrentGroup
        {
            get => _currentGroup;
            set
            {
                if (_currentGroup == value) return;
                _currentGroup = value;
                CurrentGroupChanged?.Invoke();
            }
        }

        private void Awake()
        {
            Instance = this;
            _currentGroup = Groups[0];
            Load();
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        public SkinDataBase GetSelectedItem() => GetSelectedItem(CurrentGroup.GroupType);
        public SkinDataBase GetSelectedItem(SkinGroupType group)
        {
            if (_selectedItems.TryGetValue(group, out SkinDataBase value))
            {
                return value;
            }
            return null;
        }

        public void SetSelectedItem(SkinDataBase item) => SetSelectedItem(CurrentGroup.GroupType, item);
        public void SetSelectedItem(SkinGroupType group, SkinDataBase item)
        {
            if (_selectedItems.TryGetValue(group, out SkinDataBase value) && value == item) return;
            _selectedItems[group] = item;
            SelectedItemChanged?.Invoke(CurrentGroup.GroupType, item);
        }

        public SkinDataBase GetSavedItem() => GetSavedItem(CurrentGroup.GroupType);
        public SkinDataBase GetSavedItem(SkinGroupType group)
        {
            if (_savedItems.TryGetValue(group, out SkinDataBase value))
            {
                return value;
            }
            return null;
        }

        public void SetSavedItem(SkinDataBase item) => SetSelectedItem(CurrentGroup.GroupType, item);
        public void SetSavedItem(SkinGroupType group, SkinDataBase item)
        {
            if (_savedItems.TryGetValue(group, out SkinDataBase value) && value == item) return;
            _savedItems[group] = item;
            SavedItemChanged?.Invoke(group, item);
            Save();
        }

        public void SetSelectedAsSaved() => SetSelectedAsSaved(CurrentGroup.GroupType);
        public void SetSelectedAsSaved(SkinGroupType group)
        {
            SetSavedItem(group, _selectedItems[group]);
        }

        private void Save()
        {
            var gameData = _saveSystem.GameData;
            foreach (var data in _savedItems)
            {
                switch (data.Key)
                {
                    case SkinGroupType.Character:
                        gameData.CharacterSkin = data.Value?.SkinId;
                        break;
                    case SkinGroupType.Stand:
                        gameData.StandSkin = data.Value?.SkinId;
                        break;
                    default: break;
                }
            }
            _saveSystem.Save();
        }

        private void Load()
        {
            _savedItems = new Dictionary<SkinGroupType, SkinDataBase>();
            _selectedItems = new Dictionary<SkinGroupType, SkinDataBase>();

            var data = _saveSystem.GameData;
            _savedItems[SkinGroupType.Character] = GetSkinById(data.CharacterSkin);
            _savedItems[SkinGroupType.Stand] = GetSkinById(data.StandSkin);

            foreach (SkinGroup group in Groups)
            {
                if (!_savedItems.TryGetValue(group.GroupType, out SkinDataBase skinData) || skinData == null)
                {
                    _savedItems[group.GroupType] = group.Skins[0];
                }
                _selectedItems[group.GroupType] = _savedItems[group.GroupType];
            }
        }

        public SkinDataBase GetSkinById(string id)
        {
            foreach (SkinGroup group in Groups)
            {
                foreach (SkinDataBase skinData in group.Skins)
                {
                    if (skinData.SkinId == id) return skinData;
                }
            }
            return null;
        }
    }
}
