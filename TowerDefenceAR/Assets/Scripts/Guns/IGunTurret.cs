using UnityEngine;

namespace Assets.Scripts.Guns
{
    /// <summary>
    /// Represents a gun turret with a rotating gun tower.
    /// </summary>
    public interface IGunTurret
    {
        /// <summary>
        /// Gets the gun.
        /// </summary>
        IGun Gun { get; }

        /// <summary>
        /// Sets a target point for the gun turret to rotate the gun tower towards.
        /// </summary>
        /// <param name="targetPoint">
        /// The target point to aim at
        /// </param>
        void AimAt(Vector3? targetPoint);
    }
}
