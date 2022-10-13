using DonutLab.UI.Skins;
using UnityEngine;

namespace DonutLab.SkinData
{
    public interface ISkinData
    {
        public Sprite Preview { get; }
        public string SkinId { get; }
        public void ApplyToItem(SkinPreviewElement item);
        public void ApplyToPreview(CustomisationPanel panel);
    }
}
