
namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// Represents a component which measures a game object's current absolute angular velocity.
    /// </summary>
    public interface IAngularVelocityMeter
    {
        /// <summary>
        /// Gets the game object's current absolute angular velocity.
        /// </summary>
        float CurrentAngularVelocity { get; }
    }
}
