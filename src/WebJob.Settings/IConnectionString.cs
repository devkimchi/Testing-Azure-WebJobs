namespace WebJob.Settings
{
    /// <summary>
    /// This provides interfaces that requires connection string for anything.
    /// </summary>
    public interface IConnectionString
    {
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        string ConnectionString { get; }
    }
}