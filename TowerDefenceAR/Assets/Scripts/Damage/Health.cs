using UnityEngine;

namespace Assets.Scripts.Damage
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float maxHealt = 100f;

        public float CurrentHealth { get; private set; } = 100f;
        public bool IsAlive => CurrentHealth > 0f;

        public void Damage(float damage)
        {
            CurrentHealth = Mathf.Max(0f, CurrentHealth - damage);
        }

        private void Awake()
        {
            CurrentHealth = maxHealt;
        }
    }
}
