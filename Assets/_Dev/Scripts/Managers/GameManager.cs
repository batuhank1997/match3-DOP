using System;
using _Dev.Scripts.Systems.Game;
using UnityEngine;

namespace _Dev.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameSystem m_gameSystem;
        
        private void Start()
        {
            InitializeSystems();
        }

        private void InitializeSystems()
        {
            m_gameSystem.Initialize();
        }

        private void OnDestroy()
        {
            m_gameSystem.Dispose();
        }
    }
}