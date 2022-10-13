using DG.Tweening;
using Spine;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DonutLab.UI.Skins
{
    public class CharacterPreview : MonoBehaviour
    {
        [SerializeField] private TMP_Text _skinNameText;
        [SerializeField] private Image _standPreview;
        [SerializeField] private SkeletonGraphic _characterPreview;

        private Skeleton _skeleton;

        private Tween _jumpTween;
        private Vector2 _startCharacterPos;

        private float CurrentAnimDuration => _characterPreview.AnimationState.GetCurrent(0).Animation.Duration;

        private void Awake()
        {
            _startCharacterPos = _characterPreview.rectTransform.anchoredPosition;
            _skeleton = _characterPreview.Skeleton;

            _characterPreview.AnimationState.AddAnimation(0, "idle", true, 0f);
        }

        public void SetSkinName(string skinName) => _skinNameText.text = skinName;

        public void SetStandPreview(Sprite standSprite)
        {
            _standPreview.sprite = standSprite;
        }

        public void SetCharacterPreview(string skinName)
        {
            ApplySkin(skinName);
            PlayJumpAnim();
        }

        private void PlayJumpAnim()
        {
            _characterPreview.AnimationState.SetAnimation(0, "jump rm", false);
            _characterPreview.AnimationState.AddAnimation(0, "idle", true, 0f);

            _jumpTween?.Kill();
            _characterPreview.rectTransform.anchoredPosition = _startCharacterPos + Vector2.left * 500f;
            _jumpTween = _characterPreview.rectTransform.DOAnchorPos(_startCharacterPos, CurrentAnimDuration).SetEase(Ease.OutCubic);
        }

        private void ApplySkin(string skinName)
        {
            if (string.IsNullOrEmpty(skinName))
            {
                _skeleton.SetSkin("default");
            }
            else
            {
                _skeleton.SetSkin(skinName);
            }
            _skeleton.SetSlotsToSetupPose();
            _characterPreview.AnimationState.Apply(_skeleton);
        }
    }
}
