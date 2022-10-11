using System;
using UnityEngine;

namespace DonutLab.Skins
{
    public abstract class SkinDataBase : ScriptableObject, ISkinData
    {
        [field: SerializeField] public string SkinName { get; private set; }
        [field: SerializeField] public string SkinId { get; private set; } = Guid.NewGuid().ToString();
        [field: SerializeField] public Sprite Preview { get; private set; }
    }
}
