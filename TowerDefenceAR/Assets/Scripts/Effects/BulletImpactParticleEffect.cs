using Assets.Scripts.Guns;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Effects
{
    public class BulletImpactParticleEffect : BaseHitEffect
    {
        public override void Trigger(IBullet bullet, Vector3 hitPoint)
        {
            Instantiate(bullet.ExplosionPrefab, hitPoint, Quaternion.identity);
        }
    }
}