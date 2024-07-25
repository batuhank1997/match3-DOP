using _Dev.Scripts.Data;
using _Dev.Scripts.GameUtilities;
using TMPro;
using UnityEngine;

namespace _Dev.Scripts.Presenters
{
    public class CellPresenter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private bool _debug;
        [SerializeField] private bool _rename;
        [SerializeField] private TextMeshPro _debugText;
        
        private Cell _cell;

        public void Initialize(Cell cell, int sortingOrder)
        {
            _cell = cell;
            
            if (_rename)
                gameObject.name = $"Cell {_cell.Coordinates.x} : {_cell.Coordinates.y}";
            
            _spriteRenderer.sortingOrder = sortingOrder;

            SetDebugText();
            UpdateVisuals();
        }
        
        private void SetDebugText()
        {
            if (!_debug) return;

            _debugText.sortingOrder = _spriteRenderer.sortingOrder + 1;
            _debugText.gameObject.SetActive(true);
            _debugText.GetComponent<TextMeshPro>().text = $"{_cell.Coordinates.x} : {_cell.Coordinates.y}";
        }

        private void UpdateVisuals()
        {
            UpdateSprite();
            UpdateItemPosition();
        }

        private void UpdateSprite()
        {
            _spriteRenderer.sprite = _cell.GetItemSpriteBySpecification();
        }

        private void UpdateItemPosition()
        {
            var spriteTransform = _spriteRenderer.transform;
            var localPos = spriteTransform.localPosition;
            var targetYPos = _cell.ItemDistance.Value;

            localPos = new Vector3(localPos.x, targetYPos, localPos.z);
            
            spriteTransform.localPosition = localPos;
        }

        private void Update()
        {
            UpdateVisuals();
        }
    }
}
