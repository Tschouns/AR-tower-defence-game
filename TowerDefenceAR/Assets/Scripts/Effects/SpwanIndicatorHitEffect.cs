using Assets.Scripts.Guns;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Effects
{
    public class SpwanIndicatorHitEffect : BaseHitEffect
    {
        [SerializeField]
        private GameObject hitIndicatorPrefab;

        public override void Trigger(IBullet bullet, Vector3 hitPoint)
        {
            Instantiate(hitIndicatorPrefab, hitPoint, Quaternion.identity, transform);
        }

        private void Awake()
        {
            Assert.IsNotNull(hitIndicatorPrefab, "The hit indicator prefab is not set.");
        }
    }
}
