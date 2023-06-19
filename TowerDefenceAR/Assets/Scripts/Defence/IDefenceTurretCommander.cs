
using Assets.Scripts.Battle;

namespace Assets.Scripts.Defence
{
    /// <summary>
    /// Represents a defence turret commander, i.e. the commander of a single defence turret.
    /// </summary>
    public interface IDefenceTurretCommander
    {
        /// <summary>
        /// Assigns the defence turret commander a target unit to attack.
        /// </summary>
        /// <param name="targetUnit">
        /// The target unit to attack
        /// </param>
        void AssignAttackTarget(IUnit targetUnit);
    }
}
