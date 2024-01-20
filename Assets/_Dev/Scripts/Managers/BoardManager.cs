using System.Collections.Generic;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using _Dev.Scripts.Factory;
using _Dev.Scripts.GameUtilities;
using _Dev.Scripts.System;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

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
            Debug.Log($"{GetType()} Initialized!");
            _boardFactory = new BoardFactory();
            BoardData = _boardFactory.CreateBoard(8, 8);
            MatchManager.OnCellsBlasted += OnCellsBlasted;
        }
        
        public void Dispose()
        {
            GameSystem.Instance.UnregisterManager<BoardManager>();
            MatchManager.OnCellsBlasted -= OnCellsBlasted;
            _boardFactory = null;
        }
        
        private void OnCellsBlasted(List<Cell> blastedCells)
        {
            var topCells = BoardUtility.GetBlastedCellsTopNeighbours(blastedCells);

            foreach (var cell in topCells)
            {
                var columnList = BoardUtility.GetAllTopCellsInOrder(cell);
                
                foreach (var columnCell in columnList)
                {
                    FallItem(columnCell);
                }
            }
        }

        private void FallItem(Cell cell)
        {
            var targetCell = BoardUtility.GetLastEmptyCellOnColumn(cell);
            targetCell.ItemData = new ItemData(cell.ItemData.ItemType);
            targetCell.ItemDistance.Increase(cell.Coordinates.y - targetCell.Coordinates.y);
            cell.ItemData = new ItemData(ItemType.Empty);
        }
    }
}