namespace WebJob.Settings
{
    /// <summary>
    /// This provides interfaces to configuration settings classes.
    /// </summary>
    public interface IConfigurationSettings
    {
        /// <summary>
        /// Gets a value indicating whether the application is in development or not.
        /// </summary>
        bool IsDevelopment { get; }
    }
}
