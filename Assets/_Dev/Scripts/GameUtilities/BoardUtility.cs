using _Dev.Scripts.Data;
using _Dev.Scripts.Managers;
using UnityEngine;

namespace _Dev.Scripts.GameUtilities
{
    public static class BoardUtility
    {
        public static bool TryGetCell(int x, int y, out Cell cell)
        {
            if (BoardManager.Instance.BoardData.Cells.TryGetValue(new Vector2(x, y), out var c))
            {
                cell = c;
                return true;
            }
        
            cell = null;
            return false;
        }
    }
}