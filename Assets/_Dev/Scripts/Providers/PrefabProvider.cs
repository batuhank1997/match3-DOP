using System;
using _Dev.Interfaces;
using _Dev.Scripts;
using _Dev.Scripts.Presenters;

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