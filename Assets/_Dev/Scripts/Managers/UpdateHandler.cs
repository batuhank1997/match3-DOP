using System.Collections.Generic;
using _Dev.Interfaces;
using _Dev.Scripts.Utility;
using UnityEngine;

namespace _Dev.Scripts.Managers
{
    public class UpdateHandler : Singleton<UpdateHandler>
    {
        private readonly List<ITickOnUpdate> _tickingObjects = new List<ITickOnUpdate>();

        public void SortUpdateOrder()
        {
            _tickingObjects.Sort((tick1, tick2) => tick1.TickingPriority.CompareTo(tick2.TickingPriority));
        }

        public void OnDisable()
        {
            _tickingObjects.Clear();
        }
        
        public void Register(ITickOnUpdate updatingObject)
        {
            _tickingObjects.Add(updatingObject);
        }
        
        public void Unregister(ITickOnUpdate updatingObject)
        {
            _tickingObjects.Remove(updatingObject);
        }
        
        private void Update()
        {
            foreach (var updatingObject in _tickingObjects)
                updatingObject.Tick(Time.deltaTime);
        }

    }
}