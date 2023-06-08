using UnityEngine;

namespace Assets.Scripts.Guns
{
    /// <summary>
    /// Represents an object in the game which can be hit by bullets.
    /// </summary>
    public interface IHitTarget
    {
        /// <summary>
        /// "Hits" the target, by the specified bullet, at the specified point.
        /// </summary>
        /// <param name="bullet">
        /// The bullet by which the target is hit
        /// </param>
        /// <param name="hitPoint">
        /// The point at which the target is hit
        /// </param>
        void Hit(IBullet bullet, Vector3 hitPoint);
    }
}