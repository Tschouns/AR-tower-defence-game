
using UnityEngine;

namespace Assets.Scripts.Guns
{
    /// <summary>
    /// Provides acces to the properties of a bullet.
    /// </summary>
    public interface IBullet
    {
        /// <summary>
        /// Gets the bullet's energy.
        /// </summary>
        float Energy { get; }

        /// <summary>
        /// Gets the bullet's direction of travel.
        /// </summary>
        Vector3 Direction { get; }

        /// <summary>
        /// Gets the explosion effect prefab for this bullet.
        /// </summary>
        GameObject ExplosionPrefab { get; }
    }
}
