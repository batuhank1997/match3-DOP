using UnityEngine;

namespace _Dev.Scripts.Data
{
    public class Cell
    {
        public Vector2Int Coordinates;
        public ItemData ItemData;
        public readonly ItemDistance ItemDistance;

        public Cell(ItemData itemData, Vector2Int coordinates)
        {
            ItemData = itemData;
            Coordinates = coordinates;
            ItemDistance = new ItemDistance(InGameConstants.Item.StartingItemDistance);
        }
    }
}