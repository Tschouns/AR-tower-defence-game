using System;
using UnityEngine;

namespace Assets.Scripts.Damage
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField]
        private float maxHealt = 100f;

        private bool hasDied = false;

        public event Action OnDied;
        public float CurrentHealth { get; private set; } = 100f;
        public bool IsAlive => CurrentHealth > 0f;

        public void Damage(float damage)
        {
            CurrentHealth = Mathf.Max(0f, CurrentHealth - Mathf.Abs(damage));

            if (!hasDied && !IsAlive)
            {
                hasDied = true;
                OnDied?.Invoke();
            }
        }

        private void Awake()
        {
            CurrentHealth = maxHealt;
        }
    }
}
