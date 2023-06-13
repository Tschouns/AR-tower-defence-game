namespace Assets.Scripts.Battle
{
    /// <summary>
    /// Registers enemy AI units.
    /// </summary>
    public interface IEnemyUnitRegistry
    {
        /// <summary>
        /// Registers an enemy AI unit.
        /// </summary>
        /// <param name="unit">
        /// The unit
        /// </param>
        void RegisterEnemyUnit(IUnit unit);
    }
}
