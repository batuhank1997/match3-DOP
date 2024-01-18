using System.Collections.Generic;
using _Dev.Interfaces;
using _Dev.Scripts.System;
using _Dev.Scripts.Utility;

namespace _Dev.Scripts.Managers
{
    public class UpdateManager : Singleton<UpdateManager>, IManager
    {
        private readonly List<ITickOnUpdate> _updatingObjects = new List<ITickOnUpdate>();

        public void Initialize()
        {
            GameSystem.Instance.RegisterManager(this);
        }

        public void Dispose()
        {
            GameSystem.Instance.UnregisterManager<UpdateManager>();
            _updatingObjects.Clear();
        }
        
        public void Register(ITickOnUpdate updatingObject)
        {
            _updatingObjects.Add(updatingObject);
        }
        
        public void Unregister(ITickOnUpdate updatingObject)
        {
            _updatingObjects.Remove(updatingObject);
        }
        
        private void Update()
        {
            foreach (var updatingObject in _updatingObjects)
                updatingObject.Tick();
        }

    }
}