﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Dev.Providers;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using _Dev.Scripts.Factory;
using _Dev.Scripts.GameUtilities;
using _Dev.Scripts.Systems.Game;
using _Dev.Scripts.Systems.ServiceLocator;
using Sirenix.Utilities;
using UnityEngine;

namespace _Dev.Scripts.Managers
{
    public class BoardManager : IManager
    {
        public BoardData BoardData { get; private set; }
        
        private BoardFactory _boardFactory;
        private readonly WaitForSeconds _itemCreatingDelay = new (InGameConstants.Item.NewItemCreationDelay); //TODO :::: move this to ConstantVariables

        public BoardManager()
        {
            GameSystem.Instance.RegisterManager(this);
        }

        public void Initialize()
        {
            _boardFactory = new BoardFactory();
            var levelData = ServiceLocator.Instance.Get<LevelDataProvider>().LevelData;
            BoardData = _boardFactory.CreateBoard(levelData.X, levelData.Y, levelData.LevelItems);
            SeekAndSetForPossibleSpecificBlast();

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
            UpdateHandler.Instance.StartCoroutine(FillBoardWithNewItems());
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
            cell.PossibleSkillCreationType = SkillType.None;
            
            cell.ItemDistance.Reset();
        }
        
        private IEnumerator FillBoardWithNewItems()
        {
            yield return _itemCreatingDelay;

            var emptyCells = BoardUtility.GetEmptyCells();
            if (emptyCells.IsNullOrEmpty()) yield break;
            var orderedCells = emptyCells.OrderBy(c => c.Coordinates.y).ToList();
            var offset = BoardData.Y - orderedCells[0].Coordinates.y;
            
            foreach (var cell in emptyCells)
            {
                BoardUtility.TryGetCell(cell.Coordinates.x, cell.Coordinates.y, out var spawnCell);
                spawnCell.ItemData = ItemFactory.CreateRandomItem(); //TODO :::: Create a algorithm for creating items to not lock the game
                spawnCell.ItemDistance.Set(offset * 2);
                cell.PossibleSkillCreationType = SkillType.None;
                FallItem(spawnCell);
            }
            
            SeekAndSetForPossibleSpecificBlast();
        }
        
        private void SeekAndSetForPossibleSpecificBlast()
        {
            foreach (var cells in BoardData.Cells)
            {
                foreach (var cell in cells)
                {
                    var matchData = MatchUtility.MatchSearcher.SearchMatch(cell);
                    
                    if (matchData.MatchSize <= 1)
                    {
                        cell.PossibleSkillCreationType = SkillType.None;
                        continue;
                    }
                    
                    cell.UpdateForPossibleMatch();
                }
            }
        }
    }
}