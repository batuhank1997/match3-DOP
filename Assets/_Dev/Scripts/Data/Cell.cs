using _Dev.Scripts.Enums;
using UnityEngine;

namespace _Dev.Scripts.Data
{
    public class Cell
    {
        public Vector2 Coordinates;
        public ItemData ItemData;

        public Cell(ItemData itemData, Vector2 coordinates)
        {
            ItemData = itemData;
            Coordinates = coordinates;
        }
    }
}