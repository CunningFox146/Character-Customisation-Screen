using DonutLab.Skins;
using DonutLab.UI.Skins;
using System.Collections.Generic;
using UnityEngine;
using VirtualList;

namespace DonutLab.SkinSources
{
    public abstract class SkinSourceBase<T> : ScriptableObject, IListSource where T : ISkinData
    {
        [field: SerializeField] public List<T> Skins { get; private set; }
        public int Count => Skins.Count;

        public virtual void SetItem(GameObject view, int index)
        {
            if(view.TryGetComponent(out SkinSelectItem item))
            {
                item.SetData(Skins[index]);
            }
        }
    }
}
