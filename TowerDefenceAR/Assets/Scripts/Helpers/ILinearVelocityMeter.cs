namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// Represents a component which measures a game object's current absolute linear velocity.
    /// </summary>
    public interface ILinearVelocityMeter
    {
        /// <summary>
        /// Gets the game object's current absolute linear velocity.
        /// </summary>
        float CurrentLinearVelocity { get; }
    }
}
