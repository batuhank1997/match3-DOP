using System.Collections.Generic;
using UnityEngine;

namespace _Dev.Scripts.Data
{
    public readonly struct BoardData
    {
        public readonly int X;
        public readonly int Y;

        public readonly Dictionary<Vector2Int, Cell> Cells;
        
        public BoardData(int x, int y, Dictionary<Vector2Int, Cell> cells)
        {
            X = x;
            Y = y;
            Cells = cells;
        }
    }
}