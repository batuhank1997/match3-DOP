﻿using System.Collections.Generic;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using _Dev.Scripts.GameUtilities;
using _Dev.Scripts.Interfaces;

namespace _Dev.Scripts.Skills
{
    public readonly struct BasicBomb : IItemSkill
    {
        public SkillType SkillType => SkillType.BasicBomb;
        
        public IEnumerable<Cell> GetBlastableCells(Cell centerCell)
        {
            var firstNeighbours = BoardUtility.GetAllNeighboursWithDiagonal(centerCell);
            return firstNeighbours;
        }
    }
}