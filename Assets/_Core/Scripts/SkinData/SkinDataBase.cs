using DonutLab.UI.Skins;
using System;
using UnityEngine;

namespace DonutLab.SkinData
{
    public abstract class SkinDataBase : ScriptableObject, ISkinData
    {
        [field: SerializeField] public string SkinName { get; private set; }
        [field: SerializeField] public string SkinId { get; private set; } = Guid.NewGuid().ToString();
        [field: SerializeField] public Sprite Preview { get; private set; }

        public virtual void ApplyToItem(SkinSelectItem item)
        {
            item.SetData(this);
        }

        public abstract void ApplyToPreview(CharacterPreview preview);
    }
}
