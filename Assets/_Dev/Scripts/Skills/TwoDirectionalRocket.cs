using System.Collections.Generic;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using _Dev.Scripts.Interfaces;

namespace _Dev.Scripts.Skills
{
    public readonly struct TwoDirectionalRocket : IItemSkill
    {
        public SkillType SkillType => SkillType.TwoDirectionalRocket;
        
        public IEnumerable<Cell> GetBlastableCells(Cell centerCell)
        {
            throw new System.NotImplementedException();
        }
    }
}