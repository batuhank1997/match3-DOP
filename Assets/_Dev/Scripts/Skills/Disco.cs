using System.Collections.Generic;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using _Dev.Scripts.GameUtilities;
using _Dev.Scripts.Interfaces;

namespace _Dev.Scripts.Skills
{
    public readonly struct Disco : IItemSkill
    {
        public SkillType SkillType => SkillType.Disco;
        
        public IEnumerable<Cell> GetBlastableCells(Cell centerCell)
        {
            return BoardUtility.GetAllCellsByType(centerCell.ItemData.SkillItemType);
        }
    }
}