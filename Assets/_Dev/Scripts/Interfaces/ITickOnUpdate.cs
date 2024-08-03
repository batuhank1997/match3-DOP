namespace _Dev.Interfaces
{
    public interface ITickOnUpdate
    {
        public ushort TickingPriority { get; }
        void Tick(float time);
    }
}