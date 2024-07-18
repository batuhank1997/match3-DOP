using System;
using _Dev.Interfaces;
using _Dev.Scripts.Managers;
using UnityEngine;

namespace _Dev.Scripts.Data
{
    public class ItemDistance : ITickOnUpdate
    {
        public float Value;
        private float _timeElapsed;
        private bool _isDirty;

        public ItemDistance(float value)
        {
            Value = value;
            _timeElapsed = 0f;
            _isDirty = false;
            UpdateHandler.Instance.Register(this);
        }
        
        public void Tick(float deltaTime)
        {
            Decrease(LerpDistance(deltaTime));
            _timeElapsed += deltaTime;
        }
        
        public void Increase(float value)
        {
            _isDirty = true;
            _timeElapsed = 0f;
            Value += value;
        }
        
        public void Decrease(float lerp)
        {
            Value = Mathf.Lerp(Value, 0.5f, lerp);
        }
        
        public void Set(float value)
        {
            _isDirty = true;
            _timeElapsed = 0f;
            Value = value;
        }
                
        public void Reset()
        {
            _isDirty = true;
            _timeElapsed = 0f;
            Value = InGameConstants.Item.StartingItemDistance;
        }
        
        private float LerpDistance(float t)
        {
            if (!_isDirty) return Value;
            
            if (_timeElapsed >= InGameConstants.Item.ItemDistanceLerpDuration)
            {
                _isDirty = false;
                _timeElapsed = 0f;
                return Value;
            }
            
            t = _timeElapsed / InGameConstants.Item.ItemDistanceLerpDuration;
            t = t * t * (3f - 2f * t);
            return t;
        }
    }
}