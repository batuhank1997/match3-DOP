using _Dev.Scripts.Data;
using _Dev.Scripts.GameUtilities;
using DG.Tweening;
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
            m_debugText.GetComponent<TMPro.TextMeshPro>().text = $"{_cell.Coordinates.x} : {_cell.Coordinates.y}";
        }

        private void UpdateVisuals()
        {
            m_spriteRenderer.sprite = SpriteContainer.GetSpriteByItemType(_cell.ItemData.ItemType);

            UpdateItemPosition();
        }

        private void AnimateCellBlast()
        {
            m_spriteRenderer.transform.DOScale(1.1f, 0.1f).OnComplete(() =>
            {
                m_spriteRenderer.transform.localScale = Vector3.one;
                m_spriteRenderer.sprite = SpriteContainer.GetSpriteByItemType(_cell.ItemData.ItemType);
            });
        }

        private void UpdateItemPosition()
        {
            var spriteTransform = m_spriteRenderer.transform;
            var localPos = spriteTransform.localPosition;
            
            localPos = new Vector3(localPos.x, _cell.ItemDistance.Value, localPos.z);
            
            spriteTransform.localPosition = localPos;
        }

        private void Update()
        {
            UpdateVisuals();
        }
    }
}
