using System;
using System.Collections.Generic;
using _Dev.Scripts.Systems.UINavigation.Abstract;
using _Dev.Scripts.UI.Base;
using Object = UnityEngine.Object;

namespace _Dev.Scripts.Systems.UINavigation
{
    public static class UINavigation
    {
        private static readonly Dictionary<string, PanelView> _panelViews = new (); 
        private static readonly Dictionary<string, PopupView> _popupViews = new ();
        private static readonly Dictionary<string, OverlayView> _overlayViews = new ();
        
        private static MainCanvas _mainCanvas;
        private static UIProvider _uiProvider;

        public static void Initialize(MainCanvas canvasTransform)
        {
            _mainCanvas = canvasTransform;
            _uiProvider = ServiceLocator.ServiceLocator.Instance.Get<UIProvider>();
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
            var popupViews = _uiProvider.GetPopupViews();

            foreach (var popup in popupViews)
                _popupViews.Add(popup.name, popup);
        }
        
        private static void InitializePanels()
        {
            var panelViews = _uiProvider.GetPanelViews();

            foreach (var panel in panelViews)
                _panelViews.Add(panel.name, panel);
        }
        
        private static void InitializeOverlays()
        {
            var overlays = _uiProvider.GetOverlayViews();

            foreach (var overlay in overlays)
                _overlayViews.Add(overlay.name, overlay);
        }
        
        internal static class Panel
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
        
        internal static class Popup
        {
            private static readonly Queue<PopupView> _activePopups = new ();
            private static readonly Queue<PopupView> _readyToShowPopups = new ();

            public static void OpenPopup(string popupName)
            {
                if (!_popupViews.TryGetValue(popupName, out var popup))
                    throw new ArgumentException($"There is no popup with the name {popupName} to open.");
                
                ShowPopup(popup);
            }
            
            public static void ClosePopup()
            {
                if (_activePopups == null)
                    throw new ArgumentException($"There is no active popup to close.");
                if (_activePopups.Count == 0)
                    return;

                HidePopup();
            }
            
            public static void Register(string popupName)
            {
                if (!_popupViews.TryGetValue(popupName, out var popup))
                    throw new ArgumentException($"There is no popup with the name {popupName} to open.");
                
                _readyToShowPopups.Enqueue(popup);
            }
            
            private static void HidePopup()
            {
                var popup = _activePopups.Dequeue();
                popup.Hide(default);
                Object.Destroy(popup.gameObject);

                if (_readyToShowPopups.Count <= 0) return;
                
                var firstPopupToOpen = _readyToShowPopups.Dequeue();
                var newActivePopup = Object.Instantiate(firstPopupToOpen, _mainCanvas.PopupContainer);

                _activePopups.Enqueue(newActivePopup);
                newActivePopup.Show(default);
            }
            
            private static void ShowPopup(PopupView popup)
            {
                var enqueuedPopup = Object.Instantiate(popup, _mainCanvas.PopupContainer);
                _activePopups.Enqueue(enqueuedPopup);
                enqueuedPopup.Show(default);
            }
        }
        
        internal static class Overlay
        {
            private static OverlayView _activeOverlay;

            public static void OpenOverlay(string overlayName)
            {
                if (!_overlayViews.TryGetValue(overlayName, out var overlay))
                    throw new ArgumentException($"There is no popup with the name {overlayName} to open.");
                
                ShowOverlay(overlay);
            }

            public static void CloseOverlay(string overlayName)
            {
                if (_activeOverlay == null)
                    throw new ArgumentException($"There is no active overlay {overlayName} to close.");

                HideOverlay();
            }
            
            private static void ShowOverlay(OverlayView overlay)
            {
                _activeOverlay = Object.Instantiate(overlay, _mainCanvas.OverlayContainer);
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