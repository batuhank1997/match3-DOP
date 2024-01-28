using _Dev.Interfaces;
using _Dev.Scripts.Managers;

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
        
        public void Tick(float time)
        {
            if (Value <= 0.5f) return;

            Decrease(time * 10f);
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
        
        private void Decrease(float value)
        {
            Value -= value;
        }

    }
}