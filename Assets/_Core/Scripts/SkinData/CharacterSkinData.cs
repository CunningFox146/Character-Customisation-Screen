using DonutLab.UI.Skins;
using Spine.Unity;
using UnityEngine;

namespace DonutLab.SkinData
{
    [CreateAssetMenu(menuName = "Skin Data/Character")]
    public class CharacterSkinData : SkinDataBase
    {
        [SerializeField] private SkeletonDataAsset _skeletonData;

        [field: SerializeField, SpineSkin(dataField: nameof(_skeletonData), defaultAsEmptyString: true)]
        public string Skin { get; private set; }

        public override void ApplyToPreview(CustomisationPanel panel)
        {
            panel.SetCurrentCharacterSkin(this);
        }
    }
}
