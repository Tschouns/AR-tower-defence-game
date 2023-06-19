using System.Collections.Generic;

namespace Assets.Scripts.Battle
{
    /// <summary>
    /// Provides access to all the units on the battlefield.
    /// </summary>
    public interface IUnitProvider
    {
        /// <summary>
        /// Gets all the player units.
        /// </summary>
        /// <returns>
        /// All the player units
        /// </returns>
        IReadOnlyList<IUnit> GetAlivePlayerUnits();

        /// <summary>
        /// Gets all the enemy tanks on the battlefield.
        /// </summary>
        /// <returns>
        /// All the enemy tanks
        /// </returns>
        IReadOnlyList<IUnit> GetAliveEnemyTanks();
    }
}
