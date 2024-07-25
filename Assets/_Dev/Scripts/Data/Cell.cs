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
    }
}