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
            m_spriteRenderer.sprite = _cell.ItemData.SpriteData.Sprite;
            m_spriteRenderer.sortingOrder = sortingOrder;
            gameObject.name = $"Cell {_cell.Coordinates.x} : {_cell.Coordinates.y}";
            
            SetDebugText();
        }
        
        private void SetDebugText()
        {
            if (!m_debug) return;

            m_debugText.sortingOrder = m_spriteRenderer.sortingOrder + 1;
            m_debugText.gameObject.SetActive(true);
            m_debugText.GetComponent<TMPro.TextMeshPro>().text = $"{_cell.Coordinates.x} : {_cell.Coordinates.y}";
        }
    }
}
