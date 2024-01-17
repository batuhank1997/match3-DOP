using System;
using UnityEngine;

namespace _Dev.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            InitializeSystems();
        }

        private void InitializeSystems()
        {
            try
            {
                InputManager.Instance.Initilize();
                BoardManager.Instance.Initialize();
            }
            catch (Exception e)
            {
                Debug.LogError($"Error while initializing Game Manager!: {e}");
                throw;
            }
        }
    }
}