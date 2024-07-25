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
        
        //Specific sprites
        public Sprite RedBasicBomb;
        public Sprite RedTwoDirectionalRocket;
        public Sprite RedDisco;
        public Sprite BlueBasicBomb;
        public Sprite BlueTwoDirectionalRocket;
        public Sprite BlueDisco;
        public Sprite GreenBasicBomb;
        public Sprite GreenTwoDirectionalRocket;
        public Sprite GreenDisco;
        public Sprite YellowBasicBomb;
        public Sprite YellowTwoDirectionalRocket;
        public Sprite YellowDisco;
        public Sprite PinkBasicBomb;
        public Sprite PinkTwoDirectionalRocket;
        public Sprite PinkDisco;
        public Sprite PurpleBasicBomb;
        public Sprite PurpleTwoDirectionalRocket;
        public Sprite PurpleDisco;

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
                Pink,
                RedBasicBomb,
                RedTwoDirectionalRocket,
                RedDisco,
                BlueBasicBomb,
                BlueTwoDirectionalRocket,
                BlueDisco,
                GreenBasicBomb,
                GreenTwoDirectionalRocket,
                GreenDisco,
                YellowBasicBomb,
                YellowTwoDirectionalRocket,
                YellowDisco,
                PinkBasicBomb,
                PinkTwoDirectionalRocket,
                PinkDisco,
                PurpleBasicBomb,
                PurpleTwoDirectionalRocket,
                PurpleDisco,
            };
        }
        
        public void Initialize() { }
        public void Dispose() { }
    }
}