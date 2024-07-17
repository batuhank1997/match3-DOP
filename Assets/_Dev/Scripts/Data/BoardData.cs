namespace _Dev.Scripts.Data
{
    public readonly struct BoardData
    {
        public readonly int X;
        public readonly int Y;

        public readonly Cell[][] Cells;
        
        public BoardData(int x, int y, Cell[][] cells)
        {
            X = x;
            Y = y;
            Cells = cells;
        }
    }
}