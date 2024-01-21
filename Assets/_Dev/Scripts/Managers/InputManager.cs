using System;
using _Dev.Interfaces;
using _Dev.Scripts.Data;
using _Dev.Scripts.GameUtilities;
using _Dev.Scripts.System;
using UnityEngine;

namespace _Dev.Scripts.Managers
{
    public class InputManager: IManager, ITickOnUpdate
    {
        private Camera _mainCamera;
        private BoardManager _boardManager;

        public event Action<Cell> OnClickOnCell;
        
        public InputManager()
        {
            GameSystem.Instance.RegisterManager(this);
        }

        public void Initialize()
        {
            _mainCamera = Camera.main;
            _boardManager = GameSystem.Instance.GetManager<BoardManager>();
            UpdateHandler.Instance.Register(this);
        }

        public void Dispose()
        {
            OnClickOnCell = null;
        }
      
        public void Tick()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            HandleLeftClick();
        }

        private void HandleLeftClick()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                return;
                
            var cell = GetCellUnderCursor(_boardManager.BoardData);
            if (cell == null) return;
            
            OnClickOnCell?.Invoke(cell);
        }
        
        private Cell GetCellUnderCursor(BoardData boardData)
        {
            var mousePos = (Vector2)_mainCamera.ScreenToWorldPoint(Input.mousePosition);
            var zeroPos = new Vector2(-boardData.X / 2, -boardData.Y / 2);
            
            var x = (int)Mathf.Abs(zeroPos.x - mousePos.x);
            var y = (int)Mathf.Abs(zeroPos.y - mousePos.y);
            
            return BoardUtility.TryGetCell(x, y, out var cell) ? cell : null;
        }
    }
}