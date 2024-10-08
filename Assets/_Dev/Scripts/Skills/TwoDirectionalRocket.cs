﻿using System.Collections.Generic;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using _Dev.Scripts.GameUtilities;
using _Dev.Scripts.Interfaces;
using _Dev.Scripts.Managers;
using _Dev.Scripts.Systems.Game;

namespace _Dev.Scripts.Skills
{
    public readonly struct TwoDirectionalRocket : IItemSkill
    {
        public SkillType SkillType => SkillType.TwoDirectionalRocket;
        private BoardData _boardData => GameSystem.Instance.GetManager<BoardManager>().BoardData;
     
        
        public IEnumerable<Cell> GetBlastableCells(Cell centerCell)
        {
            var cellSet = new HashSet<Cell>();
            
            AddRightSide(cellSet, centerCell);
            AddLeftSide(cellSet, centerCell);
            
            return new List<Cell>(cellSet);
        }

        private void AddRightSide(HashSet<Cell> cellsSet, Cell centerCell)
        {
            for (var i = 0; i < _boardData.X - 1; i++)
            {
                if (!BoardUtility.TryGetCell(centerCell.Coordinates.x + i, centerCell.Coordinates.y, out var cell))
                    break;                    

                cellsSet.Add(cell);
            }
        }
        
        private void AddLeftSide(HashSet<Cell> cellsSet, Cell centerCell)
        {
            for (var i = centerCell.Coordinates.x; i >= 0; i--)
            {
                if (!BoardUtility.TryGetCell(centerCell.Coordinates.x - i, centerCell.Coordinates.y, out var cell))
                    break;                    

                cellsSet.Add(cell);
            }
        }
    }
}