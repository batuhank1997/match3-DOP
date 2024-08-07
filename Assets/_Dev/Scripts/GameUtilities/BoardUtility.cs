﻿using System.Collections.Generic;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using _Dev.Scripts.Managers;
using _Dev.Scripts.Systems.Game;
using UnityEngine;

namespace _Dev.Scripts.GameUtilities
{
    public static class BoardUtility
    {
        public static bool TryGetCell(int x, int y, out Cell cell)
        {
            var boardManager = GameSystem.Instance.GetManager<BoardManager>();

            if (x < 0 || x >= boardManager.BoardData.X || y < 0 || y >= boardManager.BoardData.Y)
            {
                cell = null;
                return false;
            }
        
            cell = boardManager.BoardData.Cells[x][y];
            return true;
        }
        
        public static bool TryGetCell(Vector2 pos, out Cell cell)
        {
            var boardManager = GameSystem.Instance.GetManager<BoardManager>();

            if (pos.x < 0 || pos.x >= boardManager.BoardData.X || pos.y < 0 || pos.y >= boardManager.BoardData.Y)
            {
                cell = null;
                return false;
            }
        
            cell = boardManager.BoardData.Cells[(int)pos.x][(int)pos.y];
            return true;
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

        public static IEnumerable<Cell> GetAllNeighboursWithDiagonal(Cell cell)
        {
            var neighbours = new List<Cell>();

            var leftNeighbour = new Vector2Int(cell.Coordinates.x - 1, cell.Coordinates.y);
            var rightNeighbour = new Vector2Int(cell.Coordinates.x + 1, cell.Coordinates.y);
            var topNeighbour = new Vector2Int(cell.Coordinates.x, cell.Coordinates.y + 1);
            var bottomNeighbour = new Vector2Int(cell.Coordinates.x, cell.Coordinates.y - 1);
            var topLeftNeighbour = new Vector2Int(cell.Coordinates.x - 1, cell.Coordinates.y + 1);
            var topRightNeighbour = new Vector2Int(cell.Coordinates.x + 1, cell.Coordinates.y + 1);
            var bottomLeftNeighbour = new Vector2Int(cell.Coordinates.x - 1, cell.Coordinates.y - 1);
            var bottomRightNeighbour = new Vector2Int(cell.Coordinates.x + 1, cell.Coordinates.y - 1);

            if(TryGetCell(leftNeighbour.x, leftNeighbour.y, out var neighbourL))
                neighbours.Add(neighbourL);
            if(TryGetCell(rightNeighbour.x, rightNeighbour.y, out var neighbourR))
                neighbours.Add(neighbourR);
            if(TryGetCell(topNeighbour.x, topNeighbour.y, out var neighbourT))
                neighbours.Add(neighbourT);
            if(TryGetCell(bottomNeighbour.x, bottomNeighbour.y, out var neighbourB))
                neighbours.Add(neighbourB);
            if(TryGetCell(topLeftNeighbour.x, topLeftNeighbour.y, out var neighbourTL))
                neighbours.Add(neighbourTL);
            if(TryGetCell(topRightNeighbour.x, topRightNeighbour.y, out var neighbourTR))
                neighbours.Add(neighbourTR);
            if(TryGetCell(bottomLeftNeighbour.x, bottomLeftNeighbour.y, out var neighbourBL))
                neighbours.Add(neighbourBL);
            if(TryGetCell(bottomRightNeighbour.x, bottomRightNeighbour.y, out var neighbourBR))
                neighbours.Add(neighbourBR);

            return neighbours;
        }
        
        public static IEnumerable<Cell> GetAllCellsByType(ItemType type)
        {
            var cells = new List<Cell>();
            var boardManager = GameSystem.Instance.GetManager<BoardManager>();

            foreach (var column in boardManager.BoardData.Cells)
                foreach (var cell in column)
                    if (cell.ItemData.ItemType == type)
                        cells.Add(cell);

            return cells;
        }

        public static Cell GetLastEmptyCellBelow(Cell cell)
        {
            while (true)
            {
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
                    topCells.Add(c);
                else
                    break;
            }

            return topCells;
        }

        public static List<Cell> GetEmptyCells()
        {
            var allCells = GameSystem.Instance.GetManager<BoardManager>().BoardData.Cells;
            var emptyCells = new List<Cell>();
            
            foreach (var column in allCells)
            {
                foreach (var cell in column)
                {
                    if (cell.IsEmpty())
                        emptyCells.Add(cell);
                }
            }
            
            return emptyCells;
        }
        
        private static bool TryGetNeighbourByDirection(Cell cell, Vector2Int direction, out Cell neighbour)
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
    }
}