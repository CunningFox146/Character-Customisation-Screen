using DonutLab.SkinSources;
using UnityEngine;
using UnityEngine.UI;

namespace DonutLab.UI.Skins
{
    public class CustomisationPanel : MonoBehaviour
    {
        [SerializeField] private SkinSourceCharacter _sourceCharacter;
        [SerializeField] private SkinSourceStand _sourceStand;
        [SerializeField] private SkinsGrid _skinsGrid;

        public void ShowCharacterSkins() => _skinsGrid.SetSource(_sourceCharacter);
        public void ShowStandSkins() => _skinsGrid.SetSource(_sourceStand);
    }
}
