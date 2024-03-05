using _Dev.Scripts.Data;
using TMPro;
using UnityEngine;

namespace _Dev.Scripts.Presenters
{
    public class CellPresenter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer m_spriteRenderer;
        [SerializeField] private bool m_debug;
        [SerializeField] private TextMeshPro m_debugText;
        
        private Cell _cell;

        public void Initialize(Cell cell, int sortingOrder)
        {
            _cell = cell;
            gameObject.name = $"Cell {_cell.Coordinates.x} : {_cell.Coordinates.y}";
            m_spriteRenderer.sortingOrder = sortingOrder;

            SetDebugText();
            UpdateVisuals();
        }
        
        private void SetDebugText()
        {
            if (!m_debug) return;

            m_debugText.sortingOrder = m_spriteRenderer.sortingOrder + 1;
            m_debugText.gameObject.SetActive(true);
            m_debugText.GetComponent<TextMeshPro>().text = $"{_cell.Coordinates.x} : {_cell.Coordinates.y}";
        }

        private void UpdateVisuals()
        {
            m_spriteRenderer.sprite = SpriteContainer.GetSpriteByItemType(_cell.ItemData.ItemType);

            UpdateItemPosition();
        }

        private void UpdateItemPosition()
        {
            var spriteTransform = m_spriteRenderer.transform;
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
