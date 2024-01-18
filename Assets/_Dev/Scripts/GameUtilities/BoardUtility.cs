using System.Collections.Generic;
using _Dev.Scripts.Data;
using _Dev.Scripts.Managers;
using _Dev.Scripts.System;
using UnityEngine;

namespace _Dev.Scripts.GameUtilities
{
    public static class BoardUtility
    {
        public static bool TryGetCell(int x, int y, out Cell cell)
        {
            var boardManager = GameSystem.Instance.GetManager<BoardManager>();
            
            if (boardManager.BoardData.Cells.TryGetValue(new Vector2(x, y), out var c))
            {
                cell = c;
                return true;
            }
        
            cell = null;
            return false;
        }
        
        public static IEnumerable<Cell> GetNeighbours(Cell cell)
        {
            var neighbours = new List<Cell>();

            var leftNeighbour = new Vector2(cell.Coordinates.x - 1, cell.Coordinates.y);
            var rightNeighbour = new Vector2(cell.Coordinates.x + 1, cell.Coordinates.y);
            var topNeighbour = new Vector2(cell.Coordinates.x, cell.Coordinates.y + 1);
            var bottomNeighbour = new Vector2(cell.Coordinates.x, cell.Coordinates.y - 1);

            if(TryGetCell((int)leftNeighbour.x, (int)leftNeighbour.y, out var neighbourL))
                neighbours.Add(neighbourL);
            if(TryGetCell((int)rightNeighbour.x, (int)rightNeighbour.y, out var neighbourR))
                neighbours.Add(neighbourR);
            if(TryGetCell((int)topNeighbour.x, (int)topNeighbour.y, out var neighbourT))
                neighbours.Add(neighbourT);
            if(TryGetCell((int)bottomNeighbour.x, (int)bottomNeighbour.y, out var neighbourB))
                neighbours.Add(neighbourB);

            return neighbours;
        }
    }
}