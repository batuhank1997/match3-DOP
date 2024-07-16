using System;
using _Dev.Interfaces;
using _Dev.Scripts.Data;
using Newtonsoft.Json;
using UnityEngine;

namespace _Dev.Providers
{
    [Serializable]
    public class LevelDataProvider : IGameService
    {
        public TextAsset LevelDataJsonTextAsset;
        
        public LevelData LevelData { get; private set; }
        
        public void Initialize()
        {
            LevelData = JsonConvert.DeserializeObject<LevelData>(LevelDataJsonTextAsset.text);
        }

        public void Dispose()
        {
            LevelData = null;
        }
    }
}