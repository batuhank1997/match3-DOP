using _Dev.Scripts.Data;

namespace _Dev.Scripts.Data
{
    public readonly struct MatchData
    {
        public readonly int MatchSize;
        public readonly ItemType MatchType;
        
        public MatchData(int matchSize, ItemType matchType)
        {
            MatchSize = matchSize;
            MatchType = matchType;
        }
    }
}