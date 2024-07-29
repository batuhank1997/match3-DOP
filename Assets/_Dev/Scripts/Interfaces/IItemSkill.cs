using System.Collections.Generic;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;

namespace _Dev.Scripts.Interfaces
{
    public interface IItemSkill
    {
       SkillType SkillType { get; }
       IEnumerable<Cell> GetBlastableCells(int x, int y);
    }
}