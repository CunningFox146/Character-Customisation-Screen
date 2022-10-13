using DonutLab.UI.Skins;
using System;
using System.Collections.Generic;
using UnityEngine;
using VirtualList;

namespace DonutLab.SkinData
{
    [CreateAssetMenu(menuName = "Skin Data/Skin Group")]
    public class SkinGroup : ScriptableObject, IListSource
    {
        [field: SerializeField] public string GroupName { get; private set; }
        [field: SerializeField] public SkinGroupType GroupType { get; private set; }
        [field: SerializeField] public Sprite ButtonIcon { get; private set; }
        [field: SerializeField] public List<SkinDataBase> Skins { get; private set; }
        public int Count => Skins.Count;

        public virtual void SetItem(GameObject view, int index)
        {
            if (view.TryGetComponent(out SkinPreviewElement item))
            {
                Skins[index].ApplyToItem(item);
            }
        }
    }

    [Serializable]
    public enum SkinGroupType
    {
        Character,
        Stand
    }
}
