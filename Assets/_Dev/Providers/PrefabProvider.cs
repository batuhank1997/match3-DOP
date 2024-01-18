using System;
using _Dev.Interfaces;
using _Dev.Scripts;

namespace _Dev.Providers
{
    [Serializable]
    public class PrefabProvider : IGameService
    {
        public CellPresenter CellPresenter;
        
        public void Initialize()
        {
        }

        public void Dispose()
        {
        }
    }
}