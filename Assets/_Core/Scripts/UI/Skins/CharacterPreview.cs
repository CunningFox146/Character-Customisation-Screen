using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace DonutLab.UI.Skins
{
    public class CharacterPreview : MonoBehaviour
    {
        [SerializeField] private Image _standPreview;
        [SerializeField] private SkeletonGraphic _characterPreview;

        private void Awake()
        {
            _characterPreview.AnimationState.AddAnimation(0, "idle", true, 0f);
        }

        public void SetStandPreview(Sprite standSprite)
        {
            _standPreview.sprite = standSprite;
        }

        public void SetCharacterPreview(string skinName)
        {
            _characterPreview.Skeleton.SetSkin(skinName);
        }
    }
}
