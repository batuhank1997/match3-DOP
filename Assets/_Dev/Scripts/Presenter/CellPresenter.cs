using _Dev.Scripts.Data;
using UnityEngine;

namespace _Dev.Scripts
{
    public class CellPresenter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer m_spriteRenderer;
        
        private ItemData _itemData;

        public void Initialize(ItemData itemData, int sortingOrder)
        {
            _itemData = itemData;
            m_spriteRenderer.sprite = _itemData.SpriteData.Sprite;
            m_spriteRenderer.sortingOrder = sortingOrder;
        }
    }
}
