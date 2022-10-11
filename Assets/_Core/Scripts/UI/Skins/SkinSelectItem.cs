using DonutLab.SkinData;
using UnityEngine;
using UnityEngine.UI;

namespace DonutLab.UI.Skins
{
    public class SkinSelectItem : MonoBehaviour
    {
        [SerializeField] private Image _previewImage;
        [SerializeField] private Image _statusIcon;
        [SerializeField] private GameObject _selectedBorder;

        public string Id { get; private set; }

        public virtual void SetData(ISkinData skinData)
        {
            _previewImage.sprite = skinData.Preview;
            Id = skinData.SkinId;
        }
    }
}
