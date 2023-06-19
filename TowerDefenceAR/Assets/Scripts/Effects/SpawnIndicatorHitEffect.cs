using Assets.Scripts.Guns;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Effects
{
    public class SpawnIndicatorHitEffect : BaseHitEffect
    {
        [SerializeField]
        private GameObject hitIndicatorPrefab;

        public override void Trigger(IBullet bullet, Vector3 hitPoint)
        {
            Assert.IsNotNull(bullet);

            Instantiate(hitIndicatorPrefab, hitPoint, Quaternion.identity, transform);
        }

        private void Awake()
        {
            Assert.IsNotNull(hitIndicatorPrefab, "The hit indicator prefab is not set.");
        }
    }
}
