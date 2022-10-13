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
            _selectedItems = new Dictionary<SkinGroupType, SkinDataBase>();
            _savedItems = new Dictionary<SkinGroupType, SkinDataBase>();
            _currentGroup = Groups[0];
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
            _savedItems[group] = item;
            SavedItemChanged?.Invoke(group, item);
        }

        public void SetSelectedAsSave() => SetSelectedAsSave(CurrentGroup.GroupType);
        public void SetSelectedAsSave(SkinGroupType group)
        {
            _savedItems[group] = _selectedItems[group];
        }
    }
}
