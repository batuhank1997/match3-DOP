using UnityEngine;

namespace _Dev.Scripts.Data
{
    public readonly struct SpriteData
    {
        public readonly SpriteIdWrapper SpriteId;
        
        public SpriteData(SpriteIdWrapper spriteId)
        {
            SpriteId = spriteId;
        }
    }

    public readonly struct SpriteIdWrapper
    {
        public readonly SpriteId Id;

        public SpriteIdWrapper(SpriteId spriteId)
        {
            Id = spriteId;
        }
    }

    public enum SpriteId
    {
        Invalid = 0,
        Blue = 1,
        Green = 2,
        Orange = 3,
        Purple = 4,
        Red = 5,
        Yellow = 6,
        Pink = 7,
    }
}