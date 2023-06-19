
using UnityEngine;

namespace Assets.Scripts.Battle
{
    /// <summary>
    /// Represemts a unit fightling in a battle.
    /// </summary>
    public interface IUnit
    {
        /// <summary>
        /// Gets the unit attack priority. Higher means the unit should be attacked first.
        /// </summary>
        int AttackPriority { get; }

        /// <summary>
        /// Gets the units position.
        /// </summary>
        Vector3 Position { get; }

        /// <summary>
        /// Gets a point to attack / aim at somewhere on the unit.
        /// </summary>
        Vector3 GetAttackPoint();
    }
}
