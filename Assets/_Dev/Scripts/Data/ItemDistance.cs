using _Dev.Interfaces;
using _Dev.Scripts.Managers;
using UnityEngine;

namespace _Dev.Scripts.Data
{
    public class ItemDistance : ITickOnUpdate
    {
        public float Value;
        
        public ItemDistance(float value)
        {
            Value = value;
            UpdateHandler.Instance.Register(this);
        }
        
        public void Tick()
        {
            if (Value <= 0.5f) return;

            Decrease(Time.deltaTime * 10f);
        }
        
        public void Increase(float value)
        {
            Value += value;
        }
        
        private void Decrease(float value)
        {
            Value -= value;
        }
    }
}