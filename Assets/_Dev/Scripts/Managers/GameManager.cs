using _Dev.Scripts.Data;
using _Dev.Scripts.GameUtilities;
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
            BoardUtility.CreateBoard(new BoardData(8, 8));
        }
    }
}