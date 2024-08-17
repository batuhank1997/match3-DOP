using System;
using System.Collections.Generic;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using _Dev.Scripts.Factory;
using _Dev.Scripts.GameUtilities;
using _Dev.Scripts.Skills;
using _Dev.Scripts.Systems.Game;
using DG.Tweening;
using Sirenix.Utilities;

namespace _Dev.Scripts.Managers
{
    public class MatchManager : IManager
    {
        private InputManager _inputManager;
        
        public static event Action<List<Cell>> OnCellsBlasted;
        
        public MatchManager()
        {
            GameSystem.Instance.RegisterManager(this);
        }
        
        public void Initialize()
        {
            _inputManager = GameSystem.Instance.GetManager<InputManager>();
            
            Subscribe();
        }
        
        public void Dispose()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _inputManager = GameSystem.Instance.GetManager<InputManager>();
            _inputManager.OnClickOnCell += OnClickOnCell;
        }
        
        private void Unsubscribe()
        {
            _inputManager.OnClickOnCell -= OnClickOnCell;
        }

        private static void OnClickOnCell(Cell cell)
        {
            var allCells = new List<Cell> { cell };
            
            StartBlastingSequence(cell, allCells);
            
            if (cell.PossibleSkillCreationType != SkillType.None)
            {
                allCells.Remove(cell);
                var itemType = MatchUtility.GetSkillItemTypeByMatchSize((byte)allCells.Count);
                var itemData = new ItemData(itemType, cell.ItemData.ItemType, SkillFactory.CreateSkillBySkillType(cell.PossibleSkillCreationType), cell.ItemData.XCoord, cell.ItemData.YCoord);
                cell.TransformTo(itemData);
            }

            if (allCells.Count < 2)
                return;

            Blast(allCells);
        }

        private static void StartBlastingSequence(Cell cell, List<Cell> accumulateCells)
        {
            var blastableCells = cell.ItemData.Skill.GetBlastableCells(cell) as List<Cell> ?? new List<Cell>();

            if (blastableCells.Count == 0)
                return;
            
            var skillCellsToBlast = new List<Cell>();

            foreach (var blastable in blastableCells)
            {
                if (!accumulateCells.Contains(blastable)) 
                    accumulateCells.Add(blastable);
                
                if (blastable == cell || blastable.ItemData.Skill is NoSkill)
                    continue;
                
                accumulateCells.Remove(blastable);
                skillCellsToBlast.Add(blastable);
            }
            
            foreach (var skilledCell in skillCellsToBlast)
            {
                if (accumulateCells.Contains(skilledCell))
                    continue;
                
                Blast(accumulateCells);
                accumulateCells.Clear();
                accumulateCells.Add(skilledCell);
                StartBlastingSequence(skilledCell, accumulateCells);
            }
            
        }

        private static void Blast(List<Cell> cellsToBlast)
        {
            foreach (var blastableCell in cellsToBlast)
                blastableCell.BlastCell();
            
            OnCellsBlasted?.Invoke(cellsToBlast);
        }

        private List<Cell> SearchSkilledCellsRecursively(List<Cell> cellsToBlast)
        {
            var skillCellsToBlast = new List<Cell>();
            
            foreach (var cell in cellsToBlast)
            {
                var blastableCells = cell.ItemData.Skill.GetBlastableCells(cell);
                foreach (var c in blastableCells)
                {
                    if (c == cell || c.ItemData.Skill is NoSkill)
                        continue;
                    
                    cellsToBlast.Remove(c);
                    skillCellsToBlast.Add(c);
                }
            }

            if (skillCellsToBlast.Count == 0)
                return cellsToBlast;
            
            return SearchSkilledCellsRecursively(skillCellsToBlast);
        }
    }
}

/*var cellsToBlast = new List<Cell>(blastableCells as List<Cell> ?? new List<Cell>());
            var skillCellsToBlast = new List<Cell>();

            foreach (var c in blastableCells)
            {
                if (c == cell || c.ItemData.Skill is NoSkill)
                    continue;

                cellsToBlast.Remove(c);
                skillCellsToBlast.Add(c);
            }

            if (cell.PossibleSkillCreationType != SkillType.None)
            {
                cellsToBlast.Remove(cell);
                var itemType = MatchUtility.GetSkillItemTypeByMatchSize((byte)cellsToBlast.Count);
                var itemData = new ItemData(itemType, cell.ItemData.ItemType, SkillFactory.CreateSkillBySkillType(cell.PossibleSkillCreationType), cell.ItemData.XCoord, cell.ItemData.YCoord);
                cell.TransformTo(itemData);
                Blast(cellsToBlast);
                return;
            }

            cellsToBlast.Add(cell);

            if (cellsToBlast.Count < 2)
                return;

            Blast(cellsToBlast);

            if (skillCellsToBlast.Count == 0)
                return;

            DOVirtual.DelayedCall(0.1f, () =>
            {

            });*/