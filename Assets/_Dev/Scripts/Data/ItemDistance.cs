namespace _Dev.Scripts.Data
{
    public class ItemDistance
    {
        public float Value;
        
        public ItemDistance(float value)
        {
            Value = value;
        }
        
        public void Increase(float value)
        {
            Value += value;
        }
        
        public void Decrease(float value)
        {
            Value -= value;
        }
        
        public void Reset()
        {
            Value = 0;
        }
        
        public bool IsZero()
        {
            return Value == 0;
        }
    }
}