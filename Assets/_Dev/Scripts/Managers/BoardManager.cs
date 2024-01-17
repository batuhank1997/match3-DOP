using _Dev.Scripts.Data;
using _Dev.Scripts.GameUtilities;
using _Dev.Scripts.Utility;
using UnityEngine;

namespace _Dev.Scripts.Managers
{
    public class BoardManager : Singleton<BoardManager>
    {
        public BoardData BoardData => _boardData;
        
        private BoardData _boardData;
        private BoardFactory _boardFactory;

        public void Initialize()
        {
            _boardFactory = new BoardFactory();
            _boardData = _boardFactory.CreateBoard(8, 8);
        }
    }
}