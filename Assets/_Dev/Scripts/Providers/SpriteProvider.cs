using System;
using _Dev.Interfaces;
using UnityEngine;

namespace _Dev.Providers
{
    [Serializable]
    public class SpriteProvider : IGameService
    {
        public Sprite InValid;
        public Sprite Red;
        public Sprite Blue;
        public Sprite Green;
        public Sprite Yellow;
        public Sprite Purple;
        public Sprite Pink;

        public Sprite[] GetAllSprites()
        {
            return new []
            {
                InValid,
                Red,
                Blue,
                Green,
                Yellow,
                Purple,
                Pink
            };
        }
        
        public void Initialize() { }
        public void Dispose() { }
    }
}