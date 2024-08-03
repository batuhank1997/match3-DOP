using _Dev.Interfaces;
using _Dev.Scripts.Managers;

namespace _Dev.Scripts.Data
{
    public class ItemDistance : ITickOnUpdate
    {
        public float Value;
        public ushort TickingPriority => InGameConstants.Priority.DistanceCalculation;

        public ItemDistance(float value)
        {
            Value = value;
            UpdateHandler.Instance.Register(this);
        }


        public void Tick(float deltaTime)
        {
            Decrease(deltaTime);
        }
        
        public void Increase(float value)
        {
            Value += value;
        }
        
        private void Decrease(float deltaTime)
        {
            if (Value > 0.5f)
            {
                Value -= InGameConstants.Item.ItemFallingSpeedMultiplier * deltaTime;
                return;
            }

            if (Value <= 0.5f)
                Value = 0.5f;
        }
        
        public void Set(float value)
        {
            Value = value;
        }
                
        public void Reset()
        {
            Value = InGameConstants.Item.StartingItemDistance;
        }
    }
}