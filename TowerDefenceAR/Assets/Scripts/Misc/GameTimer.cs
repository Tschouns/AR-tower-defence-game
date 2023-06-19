using UnityEngine;

namespace Assets.Scripts.Misc
{
    /// <summary>
    /// A timer component which tracks game time.
    /// </summary>
    public class GameTimer : MonoBehaviour, ITimer
    {
        [SerializeField]
        private float duration = 10;

        [SerializeField]
        private bool isActive = false;

        public float Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public float CurrentTime { get; private set; }
        public bool IsDurationReached => CurrentTime > Duration;

        public void Reset()
        {
            CurrentTime = 0;
        }

        private void Update()
        {
            if (isActive)
            {
                CurrentTime += Time.deltaTime;
            }
        }
    }
}
