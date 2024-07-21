using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace _Dev.Scripts.UI.Base
{
    public static class UINavigation
    {
        private static readonly Dictionary<string, PanelView> _panelViews = new (); 
        private static readonly Dictionary<string, PopupView> _popupViews = new ();
        private static readonly Dictionary<string, OverlayView> _overlayViews = new ();
        
        private static MainCanvas _mainCanvas;

        public static void Initialize(MainCanvas canvasTransform)
        {
            _mainCanvas = canvasTransform;
            InitializeOverlays();
            InitializePanels();
            InitializePopups();
        }
        
        public static void Dispose()
        {
            _panelViews.Clear();
            _popupViews.Clear();
            _overlayViews.Clear();
        }
        
        private static void InitializePopups()
        {
            var popupViews = ServiceLocator.Instance.Get<UIProvider>().GetPopupViews();

            foreach (var popup in popupViews)
                _popupViews.Add(popup.name, popup);
        }
        
        private static void InitializePanels()
        {
            var panelViews = ServiceLocator.Instance.Get<UIProvider>().GetPanelViews();

            foreach (var panel in panelViews)
                _panelViews.Add(panel.name, panel);
        }
        
        private static void InitializeOverlays()
        {
            var overlays = ServiceLocator.Instance.Get<UIProvider>().GetOverlayViews();

            foreach (var overlay in overlays)
                _overlayViews.Add(overlay.name, overlay);
        }
        
        public static class Panel
        {
            private static PanelView _activePanel;
            
            public static void OpenPanel(string panelName)
            {
                if (!_panelViews.TryGetValue(panelName, out var panel))
                    throw new ArgumentException($"There is no panel with the name {panelName} to open.");
                
                _activePanel = panel;
                panel.Show(ShowPanel);
            }
            
            public static void ClosePanel(string panelName)
            {
                if (_activePanel == null)
                    throw new ArgumentException($"There is no active panel {panelName} to close.");

                _activePanel.Hide(HidePanel);
            }
            
            private static void HidePanel()
            {
                _activePanel.gameObject.SetActive(false);
            }
            
            private static void ShowPanel()
            {
                _activePanel.gameObject.SetActive(true);
            }
        }
        
        public static class Popup
        {
            private static PopupView _activePopup;

            public static void OpenPopup(string popupName)
            {
                if (!_popupViews.TryGetValue(popupName, out var popup))
                    throw new ArgumentException($"There is no popup with the name {popupName} to open.");
                
                _activePopup = popup;
                ShowPopup();
            }
            
            public static void ClosePopup(string popupName)
            {
                if (_activePopup == null)
                    throw new ArgumentException($"There is no active popup {popupName} to close.");

                HidePopup();
            }
            
            private static void HidePopup()
            {
                _activePopup.Hide(default);
                Object.Destroy(_activePopup.gameObject);
            }
            
            private static void ShowPopup()
            {
                Object.Instantiate(_activePopup, _mainCanvas.PopupContainer);
                _activePopup.Show(default);
            }
        }
        
        public static class Overlay
        {
            private static OverlayView _activeOverlay;

            public static void OpenOverlay(string overlayName)
            {
                if (!_overlayViews.TryGetValue(overlayName, out var overlay))
                    throw new ArgumentException($"There is no popup with the name {overlayName} to open.");
                
                _activeOverlay = overlay;
                ShowOverlay();
            }

            public static void CloseOverlay(string overlayName)
            {
                if (_activeOverlay == null)
                    throw new ArgumentException($"There is no active overlay {overlayName} to close.");

                HideOverlay();
            }
            
            private static void ShowOverlay()
            {
                Object.Instantiate(_activeOverlay, _mainCanvas.OverlayContainer);
                _activeOverlay.Show(default);
            }
            
            private static void HideOverlay()
            {
                _activeOverlay.Hide(default);
                Object.Destroy(_activeOverlay.gameObject);
            }
        }
    }
}