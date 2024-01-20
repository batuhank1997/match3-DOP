using System.Collections.Generic;
using _Dev.Scripts.Data;
using _Dev.Scripts.Managers;
using _Dev.Scripts.System;
using Unity.VisualScripting;
using UnityEngine;

namespace _Dev.Scripts.GameUtilities
{
    public static class BoardUtility
    {
        public static bool TryGetCell(int x, int y, out Cell cell)
        {
            var boardManager = GameSystem.Instance.GetManager<BoardManager>();
            
            if (boardManager.BoardData.Cells.TryGetValue(new Vector2Int(x, y), out var c))
            {
                cell = c;
                return true;
            }
        
            cell = null;
            return false;
        }
        
        public static IEnumerable<Cell> GetAllNeighbours(Cell cell)
        {
            var neighbours = new List<Cell>();

            var leftNeighbour = new Vector2Int(cell.Coordinates.x - 1, cell.Coordinates.y);
            var rightNeighbour = new Vector2Int(cell.Coordinates.x + 1, cell.Coordinates.y);
            var topNeighbour = new Vector2Int(cell.Coordinates.x, cell.Coordinates.y + 1);
            var bottomNeighbour = new Vector2Int(cell.Coordinates.x, cell.Coordinates.y - 1);

            if(TryGetCell(leftNeighbour.x, leftNeighbour.y, out var neighbourL))
                neighbours.Add(neighbourL);
            if(TryGetCell(rightNeighbour.x, rightNeighbour.y, out var neighbourR))
                neighbours.Add(neighbourR);
            if(TryGetCell(topNeighbour.x, topNeighbour.y, out var neighbourT))
                neighbours.Add(neighbourT);
            if(TryGetCell(bottomNeighbour.x, bottomNeighbour.y, out var neighbourB))
                neighbours.Add(neighbourB);

            return neighbours;
        }
        
        public static bool TryGetNeighbourByDirection(Cell cell, Vector2Int direction, out Cell neighbour)
        {
            var neighbourCoordinates = new Vector2Int(cell.Coordinates.x + direction.x, cell.Coordinates.y + direction.y);
            
            if (TryGetCell(neighbourCoordinates.x, neighbourCoordinates.y, out var n))
            {
                neighbour = n;
                return true;
            }

            neighbour = null;
            return false;
        }

        public static Cell GetLastEmptyCellOnColumn(Cell cell)
        {
            while (true)
            {
                //todo fix this
                if (!TryGetNeighbourByDirection(cell, Vector2Int.down, out var belowCell)) 
                    return cell;

                if (belowCell.IsEmpty())
                    cell = belowCell;
                else
                    return cell;
            }
        }

        public static List<Cell> GetBlastedCellsTopNeighbours(List<Cell> blastedCells)
        {
            var blastedCellsTopNeighbours = new List<Cell>();

            foreach (var blastedCell in blastedCells)
            {
                var topNeighbour = new Vector2(blastedCell.Coordinates.x, blastedCell.Coordinates.y + 1);
                
                if (TryGetCell((int) topNeighbour.x, (int) topNeighbour.y, out var neighbourT) && !neighbourT.IsEmpty())
                    blastedCellsTopNeighbours.Add(neighbourT);
            }

            return blastedCellsTopNeighbours;
        }

        public static List<Cell> GetAllTopCellsInOrder(Cell cell)
        {
            var topCells = new List<Cell>();

            var count = GameSystem.Instance.GetManager<BoardManager>().BoardData.Y - cell.Coordinates.y;
            
            for (var i = 0; i < count; i++)
            {
                if (TryGetCell(cell.Coordinates.x, cell.Coordinates.y + i, out var c))
                {
                    topCells.Add(c);
                }
                else
                {
                    break;
                }
            }

            return topCells;
        }
    }
}