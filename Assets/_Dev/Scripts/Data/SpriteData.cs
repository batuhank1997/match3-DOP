using UnityEngine;

namespace _Dev.Scripts.Data
{
    public readonly struct SpriteData
    {
        public readonly Sprite Sprite;
        
        public SpriteData(Sprite sprite)
        {
            Sprite = sprite;
        }
    }
}