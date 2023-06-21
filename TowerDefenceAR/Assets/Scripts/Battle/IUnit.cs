
using UnityEngine;

namespace Assets.Scripts.Battle
{
    /// <summary>
    /// Represemts a unit fightling in a battle.
    /// </summary>
    public interface IUnit
    {
        /// <summary>
        /// Gets the unit's attack range.
        /// </summary>
        float AttackRange { get; }

        /// <summary>
        /// Gets a value indicating whether the unit is alive.
        /// </summary>
        bool IsAlive { get; }

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
