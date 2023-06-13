using Assets.Scripts.Effects;
using UnityEngine;

namespace Assets.Scripts.Guns
{
    /// <summary>
    /// Implements the hit target behaviour. See: <see cref="IHitTarget"/>.
    /// </summary>
    public class HitTarget : MonoBehaviour, IHitTarget
    {
        private IHitEffect[] effects;

        public void Hit(IBullet bullet, Vector3 hitPoint)
        {
            Debug.Log("Got hit!", this);

            foreach (var effect in effects)
            {
                effect.Trigger(bullet, hitPoint);
            }
        }

        private void Awake()
        {
            effects = GetComponents<IHitEffect>();
        }
    }
}
