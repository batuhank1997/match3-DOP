using _Dev.Scripts.Data;
using _Dev.Scripts.Managers;
using _Dev.Scripts.System;
using UnityEngine;

namespace _Dev.Scripts.Logic
{
    public class MatchManager : IManager
    {
        private InputManager _inputManager;
        
        public MatchManager()
        {
            GameSystem.Instance.RegisterManager(this);
        }
        
        public void Initialize()
        {
            Debug.Log($"{GetType()} Initialized!");
            _inputManager = GameSystem.Instance.GetManager<InputManager>();
            Subscribe();
        }
        
        public void Dispose()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _inputManager = GameSystem.Instance.GetManager<InputManager>();
            _inputManager.OnClickOnCell += OnClickOnCell;
        }
        
        private void Unsubscribe()
        {
            _inputManager.OnClickOnCell -= OnClickOnCell;
        }

        private static void OnClickOnCell(Cell cell)
        {
            var match = MatchSearcher.SearchMatch(cell);

            if (match.MatchSize < 3)
                return;

            foreach (var matchCell in match.Cells)
                matchCell.Blast();
        }
    }
}