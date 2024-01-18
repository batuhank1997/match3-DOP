using System;
using _Dev.Scripts.Data;
using _Dev.Scripts.GameUtilities;
using _Dev.Scripts.Logic;
using _Dev.Scripts.Utility;
using UnityEngine;

namespace _Dev.Scripts.Managers
{
    public class InputManager : Singleton<InputManager>
    {
        private Camera _mainCamera;

        public Action<Cell> OnClickOnCell;
     
        public void Initilize()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
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
                
            var cell = GetCellUnderCursor(BoardManager.Instance.BoardData);
            if (cell == null) return;
            
            var match = MatchSearcher.SearchMatch(cell);
            
            Debug.Log($"match size: {match.MatchSize}, match type: {match.MatchType}");
            
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