using _Dev.Scripts.Data;
using _Dev.Scripts.Factory;
using _Dev.Scripts.GameUtilities;
using _Dev.Scripts.System;
using UnityEngine;

namespace _Dev.Scripts.Managers
{
    public class BoardManager : IManager
    {
        public BoardData BoardData { get; private set; }
        
        private BoardFactory _boardFactory;

        public BoardManager()
        {
            GameSystem.Instance.RegisterManager(this);
        }

        public void Initialize()
        {
            Debug.Log($"{GetType()} Initialized!");
            _boardFactory = new BoardFactory();
            BoardData = _boardFactory.CreateBoard(8, 8);
        }

        public void Dispose()
        {
            GameSystem.Instance.UnregisterManager<BoardManager>();
            _boardFactory = null;
        }
    }
}