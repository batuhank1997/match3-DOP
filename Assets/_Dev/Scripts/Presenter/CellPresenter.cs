using _Dev.Scripts.Data;
using UnityEngine;

namespace _Dev.Scripts
{
    public class CellPresenter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer m_spriteRenderer;
        
        private Cell _cell;

        public void Initialize(Cell cell, int sortingOrder)
        {
            _cell = cell;
            m_spriteRenderer.sprite = _cell.ItemData.SpriteData.Sprite;
            m_spriteRenderer.sortingOrder = sortingOrder;
        }
    }
}
