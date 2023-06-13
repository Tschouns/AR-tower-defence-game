using System;
using UnityEngine;

namespace Assets.Scripts.Building
{
    /// <summary>
    /// Represents a playing card used to build a specific building in the game.
    /// </summary>
    public interface IBuilderCard
    {
        /// <summary>
        /// Is fired when the builder card has built the building.
        /// </summary>
        event Action<GameObject> OnBuilt;

        /// <summary>
        /// Gets a value indicating whether the card has already built its building.
        /// </summary>
        bool HasBuilt { get; }
    }
}
