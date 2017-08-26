namespace WebJob.Settings
{
    /// <summary>
    /// This provides interfaces to functions settings.
    /// </summary>
    public interface IWebJobSettings : IConfigurationSettings
    {
        /// <summary>
        /// Gets the storage account settings.
        /// </summary>
        StorageAccountSettings StorageAccount { get; }
    }
}