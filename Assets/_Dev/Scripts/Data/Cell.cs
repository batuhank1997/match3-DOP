using _Dev.Scripts.GameUtilities;
using _Dev.Scripts.Logic;
using _Dev.Scripts.Skills;
using UnityEngine;

namespace _Dev.Scripts.Data
{
    public class Cell
    {
        public readonly Vector2Int Coordinates;
        public ItemData ItemData;
        public readonly ItemDistance ItemDistance;
        private ItemSkill ItemSkill;

        public Cell(ItemData itemData, Vector2Int coordinates)
        {
            ItemData = itemData;
            Coordinates = coordinates;
            ItemSkill = new NoSkill();
            ItemDistance = new ItemDistance(InGameConstants.Item.StartingItemDistance);
        }
        
        public Cell(ItemData itemData, ItemSkill itemSkill, Vector2Int coordinates)
        {
            ItemData = itemData;
            Coordinates = coordinates;
            ItemSkill = itemSkill;
            ItemDistance = new ItemDistance(InGameConstants.Item.StartingItemDistance);
        }
        
        public void SetSkill(ItemSkill itemSkill)
        {
            ItemSkill = itemSkill;
        }
        
        public ItemSkill GetSkill()
        {
            return ItemSkill;
        }
        
        public void RemoveSkill()
        {
            ItemSkill = new NoSkill();
        }

        public void UpdateForPossibleMatch()
        {
            var matchData = MatchSearcher.SearchMatch(this);
            if (matchData.MatchSize <= 1) return;
                    
            var specification = CellUtility.GetItemSpecificationForBlast(matchData.MatchSize);
            SetSkill(specification);
                
            foreach (var matchedCell in matchData.Cells)
                matchedCell.SetSkill(specification);
        }
    }
}