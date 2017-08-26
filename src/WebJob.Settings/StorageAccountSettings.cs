using System.Configuration;

namespace WebJob.Settings
{
    /// <summary>
    /// This represents the settings entity for storage account.
    /// </summary>
    public class StorageAccountSettings : IConnectionString
    {
        private const string StorageAccountConnectionString = "AzureWebJobsStorage";

        /// <inheritdoc />
        public virtual string ConnectionString => GetConnectionString();

        private static string GetConnectionString()
        {
            var connString = ConfigurationManager.ConnectionStrings[StorageAccountConnectionString].ConnectionString;
            if (string.IsNullOrWhiteSpace(connString))
            {
                connString = ConfigurationManager.AppSettings[StorageAccountConnectionString];
            }

            return connString;
        }
    }
}