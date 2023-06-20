using Assets.Scripts.Damage;
using Assets.Scripts.Guns;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Effects
{
    public class DamageHealthEffect : BaseHitEffect
    {
        [SerializeField]
        private Health health;

        [SerializeField]
        private float energyDamageFactor = 1f;

        public override void Trigger(IBullet bullet, Vector3 hitPoint)
        {
            Assert.IsNotNull(bullet);

            health.Damage(bullet.Energy * energyDamageFactor);
        }

        private void Awake()
        {
            Assert.IsNotNull(health, "The health reference is not set.");
        }
    }
}
