using System;
using System.Collections.Generic;
using _Dev.Scripts.Logic;
using _Dev.Scripts.Managers;
using _Dev.Scripts.Utility;

namespace _Dev.Scripts.System
{
    public class GameSystem : Singleton<GameSystem>
    {
        private readonly Dictionary<string, IManager> _managers = new Dictionary<string, IManager>();

        public void Initialize()
        {
            AddManagers();
            InitializeManagers();
        }

        private void InitializeManagers()
        {
            foreach (var manager in _managers)
                manager.Value.Initialize();
        }

        private void AddManagers()
        {
            _managers.Add(nameof(InputManager), new InputManager());
            _managers.Add(nameof(BoardManager), new BoardManager());
            _managers.Add(nameof(MatchManager), new MatchManager());
            _managers.Add(nameof(UpdateManager), UpdateManager.Instance);
        }
        
        public T GetManager<T>() where T : IManager
        {
            var key = typeof(T).Name;
            
            if (_managers.TryGetValue(key, out var manager)) 
                return (T)manager;
            
            throw new InvalidOperationException();
        }
        
        public void RegisterManager<T>(T manager) where T : IManager
        {
            var key = typeof(T).Name;
            
            if (_managers.ContainsKey(key))
                return;

            _managers.Add(key, manager);
        }
        
        public void UnregisterManager<T>() where T : IManager
        {
            var key = typeof(T).Name;
            
            if (!_managers.ContainsKey(key))
                return;

            _managers.Remove(key);
        }
        
        public void Dispose()
        {
            foreach (var manager in _managers)
                manager.Value.Dispose();
            
            _managers.Clear();
        }
    }
}