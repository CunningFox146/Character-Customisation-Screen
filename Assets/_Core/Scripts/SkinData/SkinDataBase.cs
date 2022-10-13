using DonutLab.UI.Skins;
using UnityEngine;

namespace DonutLab.SkinData
{
    public abstract class SkinDataBase : ScriptableObject, ISkinData
    {
        [field: SerializeField] public string SkinName { get; private set; }
        [field: SerializeField] public string SkinId { get; private set; }
        [field: SerializeField] public bool IsLocked { get; private set; }
        [field: SerializeField] public Sprite Preview { get; private set; }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (string.IsNullOrEmpty(SkinId))
            {
                SkinId = SkinName.GetHashCode().ToString();
            }
        }
#endif

        public virtual void ApplyToItem(SkinPreviewElement item)
        {
            item.SetData(this);
        }

        public abstract void ApplyToPreview(CustomisationPanel panel);
    }
}
