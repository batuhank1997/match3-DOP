using System;
using _Dev.Interfaces;
using _Dev.Scripts;
using UnityEngine;

namespace _Dev.Providers
{
    [Serializable]
    public class PrefabProvider : IGameService
    {
        public CellPresenter CellPresenter;
    }

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
    }
}