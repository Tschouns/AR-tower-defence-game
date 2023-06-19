using UnityEngine;

namespace Assets.Scripts.Guns
{
    /// <summary>
    /// Represents a gun tower with gun which can be elevated.
    /// </summary>
    public interface IGunTower
    {
        /// <summary>
        /// Gets the gun.
        /// </summary>
        IGun Gun { get; }

        /// <summary>
        /// Sets a target point for the gun tower to aim the gun at.
        /// </summary>
        /// <param name="targetPoint">
        /// The target point to aim at
        /// </param>
        void AimAt(Vector3? targetPoint);
    }
}
