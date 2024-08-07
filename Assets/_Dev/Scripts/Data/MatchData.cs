﻿using System.Collections.Generic;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;

namespace _Dev.Scripts.Data
{
    public readonly struct MatchData
    {
        public readonly byte MatchSize;
        public readonly ItemType MatchType;
        public readonly List<Cell> Cells;
        
        public MatchData(byte matchSize, List<Cell> cells, ItemType matchType)
        {
            MatchSize = matchSize;
            MatchType = matchType;
            Cells = cells;
        }
        
        public static readonly MatchData Invalid = new(0, new List<Cell>(), ItemType.Invalid);
    }
}