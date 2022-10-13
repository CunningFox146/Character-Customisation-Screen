using DonutLab.UI.Skins;
using Spine.Unity;
using UnityEngine;

namespace DonutLab.SkinData
{
    [CreateAssetMenu(menuName = "Skin Data/Character")]
    public class CharacterSkinData : SkinDataBase
    {
        [field: SerializeField] public SkeletonDataAsset PreviewSkeleton { get; private set; }

        public override void ApplyToPreview(CharacterPreview preview)
        {
            throw new System.NotImplementedException();
        }
    }
}
