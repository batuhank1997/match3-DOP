using _Dev.Scripts.Data;
using _Dev.Scripts.GameUtilities;

namespace _Dev.Scripts.Managers
{
    public class BoardManager : IManager
    {
        public BoardData BoardData { get; private set; }
        
        private BoardFactory _boardFactory;

        public void Initialize()
        {
            _boardFactory = new BoardFactory();
            BoardData = _boardFactory.CreateBoard(8, 8);
        }

        public void Dispose()
        {
            _boardFactory = null;
        }
    }
}