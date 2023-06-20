
namespace Assets.Scripts.Game
{
    /// <summary>
    /// Represents the game. Provides game status info.
    /// </summary>
    public interface IGame
    {
        bool IsTowerBuilt { get; }
        bool IsEnemySpawnPointBuilt { get; }
        int DefencesBuilt { get; }
        int ObstaclesBuilt { get; }
        bool HasDefencesLeftToBuild { get; }
        bool HasObstaclesLeftToBuild { get; }
    }
}
