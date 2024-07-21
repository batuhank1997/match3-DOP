using System;
using System.Collections.Generic;
using _Dev.Interfaces;
using _Dev.Scripts.Systems.UINavigation;
using _Dev.Scripts.Systems.UINavigation.Abstract;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Dev.Scripts.UI.Base
{
    [Serializable]
    public class UIProvider : IGameService
    {
        [SerializeField] private List<PanelView> _panelViews = new (); 
        [SerializeField] private List<PopupView> _popupViews = new ();
        [SerializeField] private List<OverlayView> _overlayViews = new ();
        
        public void Initialize()
        {
            var canvasTransform = Object.FindObjectOfType<MainCanvas>();
            UINavigation.Initialize(canvasTransform);
        }

        public void Dispose()
        {
            UINavigation.Dispose();
        }
        
        public List<PanelView> GetPanelViews()
        {
            return _panelViews;
        }
        
        public List<PopupView> GetPopupViews()
        {
            return _popupViews;
        }
        
        public List<OverlayView> GetOverlayViews()
        {
            return _overlayViews;
        }
    }
}