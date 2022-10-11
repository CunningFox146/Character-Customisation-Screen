using Spine.Unity;
using UnityEngine;

namespace DonutLab.Skins
{
    [CreateAssetMenu(menuName = "Skin Data/Character")]
    public class CharacterSkinData : SkinDataBase
    {
        [field: SerializeField] public SkeletonDataAsset PreviewSkeleton { get; private set; }
    }
}
