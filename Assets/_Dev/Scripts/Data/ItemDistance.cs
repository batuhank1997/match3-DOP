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
        
        public void Tick(float deltaTime)
        {
            if (Value <= 0.5f) return;

            Decrease(deltaTime * 10f);
        }
        
        public void Increase(float value)
        {
            Value += value;
        }
        
        public void Set(float value)
        {
            Value = value;
        }
                
        public void Reset()
        {
            Value = InGameConstants.Item.StartingItemDistance;
        }
        
        private void Decrease(float lerp)
        {
            Value = Mathf.Lerp(Value, 0, lerp);
        }

    }
}