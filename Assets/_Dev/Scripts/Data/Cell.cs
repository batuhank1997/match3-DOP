using _Dev.Scripts.Enums;
using _Dev.Scripts.GameUtilities;
using _Dev.Scripts.Skills;
using UnityEngine;

namespace _Dev.Scripts.Data
{
    public class Cell
    {
        public readonly Vector2Int Coordinates;
        public ItemData ItemData;
        public readonly ItemDistance ItemDistance;
        public SkillType PossibleSkillCreationType;

        public Cell(ItemData itemData, Vector2Int coordinates)
        {
            ItemData = itemData;
            Coordinates = coordinates;
            PossibleSkillCreationType = SkillType.None;
            ItemDistance = new ItemDistance(InGameConstants.Item.StartingItemDistance);
        }
        
        public void SetSkillPossibilityType(SkillType skillType)
        {
            PossibleSkillCreationType = skillType;
        }
        
        public void TransformTo(ItemData newItemData)
        {
            ItemData = newItemData;
        }

        public void UpdateForPossibleMatch()
        {
            var matchData = MatchUtility.MatchSearcher.SearchMatch(this);
            if (matchData.MatchSize <= 1) return;
                    
            var specification = CellUtility.GetSkillTypeByBlastSize(matchData.MatchSize);
            SetSkillPossibilityType(specification);
                
            foreach (var matchedCell in matchData.Cells)
                matchedCell.SetSkillPossibilityType(specification);
        }
    }
}