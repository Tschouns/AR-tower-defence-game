namespace Assets.Scripts.Battle
{
    /// <summary>
    /// Registers player units.
    /// </summary>
    public interface IPlayerUnitRegistry
    {
        /// <summary>
        /// Registers a player unit.
        /// </summary>
        /// <param name="unit">
        /// The unit
        /// </param>
        void RegisterPlayerUnit(IUnit unit);
    }
}
