using System;
using System.Collections.Generic;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using _Dev.Scripts.Factory;
using _Dev.Scripts.GameUtilities;
using _Dev.Scripts.Systems.Game;

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
            var blastableCells = cell.ItemData.Skill.GetBlastableCells(cell);
            var cellsToBlast = new List<Cell>(blastableCells);
            
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
            Blast(cellsToBlast);
        }

        private static void Blast(List<Cell> cellsToBlast)
        {
            foreach (var blastableCell in cellsToBlast)
                blastableCell.BlastCell();
            
            OnCellsBlasted?.Invoke(cellsToBlast);
        }
    }
}