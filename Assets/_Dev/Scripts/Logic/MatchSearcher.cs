using System.Collections.Generic;
using _Dev.Scripts.Data;
using _Dev.Scripts.GameUtilities;

namespace _Dev.Scripts.Logic
{
    public static class MatchSearcher
    {
        private static readonly List<Cell> _traversedCells = new List<Cell>();
        private static byte _matchSizeCounter = 0;

        public static MatchData SearchMatch(Cell clickedCell)
        {
            _matchSizeCounter = 0;
            _traversedCells.Clear();
            
            var match = CheckNeighbours(clickedCell);
            return match;
        }

        private static MatchData CheckNeighbours(Cell cell)
        {
            var match = new MatchData(0, _traversedCells, cell.ItemData.ItemType);

            var neighbours = BoardUtility.GetAllNeighbours(cell);

            foreach (var neighbourCell in neighbours)
            {
                var isSameItem = neighbourCell.ItemData.ItemType == cell.ItemData.ItemType;
                var isAlreadyTraversed = _traversedCells.Contains(neighbourCell);
                
                if (!isSameItem || isAlreadyTraversed) continue;
                
                _matchSizeCounter++;
                _traversedCells.Add(neighbourCell);
                CheckNeighbours(neighbourCell);
            }

            return new MatchData(_matchSizeCounter, _traversedCells, match.MatchType);
        }

    }
}