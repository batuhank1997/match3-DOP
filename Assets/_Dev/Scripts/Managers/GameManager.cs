using _Dev.Scripts.Data;
using UnityEngine;

namespace _Dev.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            Initialize();
        }

        private static void Initialize()
        {
            var board = new Board(8, 8);
            board.CreateBoard();
        }
    }
}