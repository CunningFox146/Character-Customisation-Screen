using UnityEngine;

namespace DonutLab.Skins
{
    [CreateAssetMenu(menuName = "Skin Data/Stand")]
    public class StandSkinData : SkinDataBase
    {
        [field: SerializeField] public Sprite GameSprite { get; private set; }
    }
}
