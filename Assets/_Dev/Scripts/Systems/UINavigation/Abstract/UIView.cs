using System;
using UnityEngine;

namespace _Dev.Scripts.Systems.UINavigation.Abstract
{
    public abstract class UIView : MonoBehaviour
    {
        public abstract string Name { get; }
        
        public event Action<string> OnShow;
        public event Action<string> OnHide;

        public virtual void Show(Action callback = default)
        {
            PlayOpenAnimation(callback);
            OnShow?.Invoke(Name);
        }

        public virtual void Hide(Action callback = default)
        {
            PlayCloseAnimation(callback);
            OnHide?.Invoke(Name);
        }
        
        private static void PlayOpenAnimation(Action callback)
        {
            //TODO :::: Implement Wait for animation to finish before invoking callback
            callback?.Invoke();
        }
        
        private static void PlayCloseAnimation(Action callback)
        {
            //TODO :::: Implement Wait for animation to finish before invoking callback
            callback?.Invoke();
        }
    }
}
