using UnityEngine;

namespace _Dev.Scripts.Data
{
    public class Cell
    {
        public Vector2 Coordinates;
        public ItemData ItemData;
        public ItemDistance ItemDistance;

        public Cell(ItemData itemData, Vector2 coordinates)
        {
            ItemData = itemData;
            Coordinates = coordinates;
            ItemDistance = new ItemDistance(InGameConstants.Item.StartingItemDistance);
        }
    }
}