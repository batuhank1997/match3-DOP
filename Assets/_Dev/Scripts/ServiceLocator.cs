using System;
using _Dev.Interfaces;
using _Dev.Scripts.Utility;
using UnityEngine;

namespace _Dev
{
    public class ServiceLocator : Singleton<ServiceLocator>
    {
        [SerializeField] public ServicesDictionary m_servicesDictionary;
        
        public T Get<T>() where T : IGameService
        {
            var key = typeof(T).Name;

            if (m_servicesDictionary.service.TryGetValue(key, out var service)) 
                return (T)service;
            
            Debug.LogError($"{key} not registered with {GetType().Name}");
            throw new InvalidOperationException();
        }
        
        public void Register<T>(T service) where T : IGameService
        {
            var key = typeof(T).Name;
            
            if (m_servicesDictionary.service.ContainsKey(key))
            {
                Debug.LogError($"Attempted to register service of type {key} which is already registered with the {GetType().Name}.");
                return;
            }

            m_servicesDictionary.service.Add(key, service);
        }
        
        public void Unregister<T>() where T : IGameService
        {
            var key = typeof(T).Name;
            
            if (!m_servicesDictionary.service.ContainsKey(key))
            {
                Debug.LogError($"Attempted to unregister service of type {key} which is not registered with the {GetType().Name}.");
                return;
            }

            m_servicesDictionary.service.Remove(key);
        }
        
        public bool IsRegistered<T>()
        {
            var key = typeof(T).Name;
            
            return m_servicesDictionary.service.ContainsKey(key);
        }

        private void OnEnable()
        {
            foreach (var service in m_servicesDictionary.service)
                service.Value.Initialize();
        }

        private void OnDestroy()
        {
            foreach (var service in m_servicesDictionary.service)
                service.Value.Dispose();
        }
    }
}