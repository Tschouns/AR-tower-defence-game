using Assets.Scripts.Guns;
using UnityEngine;

namespace Assets.Scripts.Effects
{
    /// <summary>
    /// Represents a "hit effect", i.e. an effect which is a reaction to a bullet hit.
    /// </summary>
    public interface IHitEffect
    {
        /// <summary>
        /// Triggers the effect.
        /// </summary>
        /// <param name="bullet">
        /// The bullet by which the target is hit
        /// </param>
        /// <param name="hitPoint">
        /// The point at which the target is hit
        /// </param>
        void Trigger(IBullet bullet, Vector3 hitPoint);
    }
}
