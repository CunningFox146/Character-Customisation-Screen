using DonutLab.UI.Skins;
using UnityEngine;

namespace DonutLab.SkinData
{
    [CreateAssetMenu(menuName = "Skin Data/Stand")]
    public class StandSkinData : SkinDataBase
    {
        [field: SerializeField] public Sprite GameSprite { get; private set; }

        public override void ApplyToPreview(CustomisationPanel panel)
        {
            panel.SetCurrentStandSkin(this);
        }
    }
}
