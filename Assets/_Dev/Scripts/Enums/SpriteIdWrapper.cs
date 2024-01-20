using _Dev.Scripts.Enums;

namespace _Dev.Scripts.Data
{
    public readonly struct SpriteIdWrapper
    {
        public readonly SpriteId Id;

        public SpriteIdWrapper(SpriteId spriteId)
        {
            Id = spriteId;
        }
    }
}