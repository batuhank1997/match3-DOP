using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using _Dev.Scripts.Factory;
using _Dev.Scripts.GameUtilities;
using _Dev.Scripts.System;
using UnityEngine;

namespace _Dev.Scripts.Managers
{
    public class BoardManager : IManager
    {
        public BoardData BoardData { get; private set; }
        
        private BoardFactory _boardFactory;

        public BoardManager()
        {
            GameSystem.Instance.RegisterManager(this);
        }

        public void Initialize()
        {
            _boardFactory = new BoardFactory();
            BoardData = _boardFactory.CreateBoard(8, 8);
            MatchManager.OnCellsBlasted += OnCellsBlasted;
        }
        
        public void Dispose()
        {
            MatchManager.OnCellsBlasted -= OnCellsBlasted;
            _boardFactory = null;
        }
        
        private void OnCellsBlasted(List<Cell> blastedCells)
        {
            FallItemsOnTop(blastedCells);
            UpdateHandler.Instance.StartCoroutine(FillBoardWithNewItems(blastedCells));
        }

        private static void FallItemsOnTop(List<Cell> blastedCells)
        {
            var topCells = BoardUtility.GetBlastedCellsTopNeighbours(blastedCells);
                
            foreach (var cell in topCells)
            {
                var columnList = BoardUtility.GetAllTopCellsInOrder(cell);
                
                foreach (var columnCell in columnList)
                    FallItem(columnCell);
            }
        }

        private static void FallItem(Cell cell)
        {
            var targetCell = BoardUtility.GetLastEmptyCellBelow(cell);
            targetCell.ItemData = cell.ItemData;
            targetCell.ItemDistance.Increase(cell.Coordinates.y - targetCell.Coordinates.y);
            if (cell == targetCell) return;

            cell.ItemData = new ItemData(ItemType.Empty);
            cell.ItemDistance.Reset();
        }

        private IEnumerator FillBoardWithNewItems(List<Cell> blastedCell)
        {
            blastedCell = blastedCell.OrderBy(c => c.Coordinates.y).ToList();
            
            foreach (var cell in blastedCell)
            {
                BoardUtility.GetCell(cell.Coordinates.x, BoardData.Y - 1, out var spawnCell);
                spawnCell.ItemData = ItemFactory.CreateRandomItem();
                spawnCell.ItemDistance.Reset();
                FallItem(spawnCell);
            }
            
            
            yield return null;
        }
    }
}