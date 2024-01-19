using System;
using System.Collections.Generic;
using System.Reflection;
using _Dev.Scripts.Managers;
using _Dev.Scripts.Utility;

namespace _Dev.Scripts.System
{
    public class GameSystem : Singleton<GameSystem>
    {
        private readonly Dictionary<string, IManager> _managers = new Dictionary<string, IManager>();

        public void Initialize()
        {
            GetManagers();
            InitializeManagers();
        }
        
        private static void GetManagers()
        {
            var managers = Assembly.GetAssembly(typeof(IManager)).GetTypes();
            
            foreach (var manager in managers)
            {
                if (manager.IsInterface || manager.IsAbstract)
                    continue;

                if (!typeof(IManager).IsAssignableFrom(manager)) continue;
                Activator.CreateInstance(manager);
            }
        }

        private void InitializeManagers()
        {
            foreach (var manager in _managers)
                manager.Value.Initialize();
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