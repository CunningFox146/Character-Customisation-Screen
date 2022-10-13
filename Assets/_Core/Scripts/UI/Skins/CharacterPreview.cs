using DG.Tweening;
using Spine;
using Spine.Unity;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DonutLab.UI.Skins
{
    public class CharacterPreview : MonoBehaviour
    {
        public event Action SelectButtonClicked;

        [SerializeField] private TMP_Text _skinNameText;
        [SerializeField] private Image _standPreview;
        [SerializeField] private SkeletonGraphic _characterPreview;
        [SerializeField] private Button _selectButton;
        [SerializeField] private GameObject _lockedHint;

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

        private void OnEnable()
        {
            _selectButton.onClick.AddListener(OnSelectButtonClickedHandler);
        }

        private void OnDisable()
        {
            _selectButton.onClick.RemoveListener(OnSelectButtonClickedHandler);
        }

        public void SetSkinName(string skinName) => _skinNameText.text = skinName;

        public void SetIsSaved(bool isSelected)
        {
            _selectButton.gameObject.SetActive(!isSelected);
        }

        public void SetIsLocked(bool isLocked)
        {
            if (isLocked)
            {
                _selectButton.gameObject.SetActive(isLocked);
            }
            _lockedHint.SetActive(isLocked);
        }

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

        private void OnSelectButtonClickedHandler()
        {
            SetIsSaved(true);
            SelectButtonClicked?.Invoke();
        }
    }
}
