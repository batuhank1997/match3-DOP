using UnityEngine;

namespace _Dev.Scripts.UI
{
    public class MainCanvas : MonoBehaviour
    {
        [SerializeField] private Transform _panelContainer;
        [SerializeField] private Transform _popupContainer;
        [SerializeField] private Transform _overlayContainer;
        
        public Transform PanelContainer => _panelContainer;
        public Transform PopupContainer => _popupContainer;
        public Transform OverlayContainer => _overlayContainer;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
