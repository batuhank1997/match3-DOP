using UnityEngine;

namespace _Dev.Scripts.Utility
{
    public class TimeController : MonoBehaviour
    {
        [Range(0, 2)]
        public float TimeScale = 1;
        
        private void Update()
        {
            Time.timeScale = TimeScale;
        }
    }
}
