using UnityEngine;
using VirtualList;

namespace DonutLab.UI.Skins
{
    public class SkinsGrid : MonoBehaviour
    {
        [SerializeField] private VirtualGridList _gridList;

        public void SetSource(IListSource source) => _gridList.SetSource(source);
    }
}
