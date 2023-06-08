using Assets.Scripts.Guns;
using UnityEngine;

namespace Assets.Scripts.Effects
{
    /// <summary>
    /// Base class for hit effects. Also see: <see cref="IHitEffect"/>.
    /// </summary>
    [RequireComponent(typeof(HitTarget))]
    public abstract class BaseHitEffect : MonoBehaviour, IHitEffect
    {
        public abstract void Trigger(IBullet bullet, Vector3 hitPoint);
    }
}
