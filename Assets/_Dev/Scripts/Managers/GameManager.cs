using _Dev.Scripts.System;
using UnityEngine;

namespace _Dev.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameSystem m_gameSystem;
        
        private void Awake()
        {
            InitializeSystems();
        }

        private void InitializeSystems()
        {
            m_gameSystem.Initialize();
        }
    }
}