using System;

namespace Assets.Scripts.Damage
{
    /// <summary>
    /// Represents an object's health.
    /// </summary>
    public interface IHealth
    {
        /// <summary>
        /// Fired when the object dies.
        /// </summary>
        event Action OnDied;

        /// <summary>
        /// Gets the current health.
        /// </summary>
        float CurrentHealth { get; }

        /// <summary>
        /// Gets a value indicating whether the object is alive.
        /// </summary>
        bool IsAlive { get; }

        /// <summary>
        /// Causes the specified amount of damage to the object.
        /// </summary>
        /// <param name="damage">
        /// The amount of damage caused
        /// </param>
        void Damage(float damage);
    }
}
