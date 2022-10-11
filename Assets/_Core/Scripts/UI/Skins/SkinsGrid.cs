using DonutLab.Skins;
using DonutLab.SkinSources;
using UnityEngine;
using VirtualList;

namespace DonutLab.UI.Skins
{
    public class SkinsGrid : MonoBehaviour
    {
        [SerializeField] private VirtualGridList _gridList;
        [SerializeField] private SkinSourceCharacter _characterSkinData;

        public void SetSource(IListSource source) => _gridList.SetSource(source);

        private void Awake()
        {
            SetSource(_characterSkinData);
        }
    }
}
