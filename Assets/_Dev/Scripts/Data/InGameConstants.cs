namespace _Dev.Scripts.Data
{
    public static class InGameConstants
    {
        public static class Item
        {
            public const float StartingItemDistance = 0.5f;
            public const float ItemDistanceLerpDuration = 2f;
            public const float NewItemCreationDelay = 0f;
            public const float ItemFallingSpeedMultiplier = 10f;
        }
        
        public static class Priority
        {
            public const ushort First = 0;
            public const ushort Input = 1;
            public const ushort DistanceCalculation = 2;
        }
    }
}