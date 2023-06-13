﻿using Assets.Scripts.Battle;

namespace Assets.Scripts.Enemy
{
    /// <summary>
    /// Represents a tank commander, i.e. the commander of a single tank.
    /// </summary>
    public interface IEnemyTankCommander
    {
        /// <summary>
        /// Assigns the tank commander a target unit to attack.
        /// </summary>
        /// <param name="targetUnit">
        /// The target unit to attack
        /// </param>
        void AssignAttackTarget(IUnit targetUnit);
    }
}
