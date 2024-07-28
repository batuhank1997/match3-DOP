using _Dev.Scripts.GameUtilities;
using _Dev.Scripts.Logic;
using _Dev.Scripts.Managers;
using UnityEngine;

namespace _Dev.Scripts.Data
{
    public class Cell
    {
        public readonly Vector2Int Coordinates;
        public ItemData ItemData;
        public readonly ItemDistance ItemDistance;
        public ItemSpecification ItemSpecification;

        public Cell(ItemData itemData, Vector2Int coordinates)
        {
            ItemData = itemData;
            Coordinates = coordinates;
            ItemSpecification = ItemSpecification.Invalid;
            ItemDistance = new ItemDistance(InGameConstants.Item.StartingItemDistance);
        }
        
        public Cell(ItemData itemData, ItemSpecification itemSpecification, Vector2Int coordinates)
        {
            ItemData = itemData;
            Coordinates = coordinates;
            ItemSpecification = itemSpecification;
            ItemDistance = new ItemDistance(InGameConstants.Item.StartingItemDistance);
        }
        
        public void AddSpecification(ItemSpecification itemSpecification)
        {
            ItemSpecification = itemSpecification;
        }

        public void UpdateForPossibleMatch()
        {
            var matchData = MatchSearcher.SearchMatch(this);
            if (matchData.MatchSize <= 1) return;
                    
            var specification = CellUtility.GetItemSpecificationForBlast(matchData.MatchSize);
            AddSpecification(specification);
                
            foreach (var matchedCell in matchData.Cells)
                matchedCell.AddSpecification(specification);
        }
    }
}