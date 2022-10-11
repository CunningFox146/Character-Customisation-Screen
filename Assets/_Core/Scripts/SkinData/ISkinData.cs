using UnityEngine;

namespace DonutLab.Skins
{
    public interface ISkinData
    {
        public Sprite Preview { get; }
        public string SkinId { get; }
    }
}
