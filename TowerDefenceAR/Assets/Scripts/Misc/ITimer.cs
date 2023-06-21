namespace Assets.Scripts.Misc
{
    /// <summary>
    /// Represents a timer.
    /// </summary>
    public interface ITimer
    {
        /// <summary>
        /// Gets or sets the timer duration.
        /// </summary>
        float Duration { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the timer is currently active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the current time.
        /// </summary>
        float CurrentTime { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the duration has already been reached.
        /// </summary>
        bool IsDurationReached { get; }

        /// <summary>
        /// Resets the timer, i.e. sets the current time to 0.
        /// </summary>
        void Reset();
    }
}
