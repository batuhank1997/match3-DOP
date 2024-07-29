using System.Collections.Generic;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using _Dev.Scripts.Interfaces;

namespace _Dev.Scripts.Skills
{
    public readonly struct Disco : IItemSkill
    {
        public SkillType SkillType => SkillType.Disco;
        
        public IEnumerable<Cell> GetBlastableCells(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}