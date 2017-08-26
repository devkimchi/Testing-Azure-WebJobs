using System;
using System.Configuration;

namespace WebJob.Settings
{
    /// <summary>
    /// This represents the configuration settings entity for Azure Functions.
    /// </summary>
    public class WebJobConfigurationSettings : IWebJobSettings
    {
        /// <inheritdoc />
        public virtual bool IsDevelopment => Convert.ToBoolean(ConfigurationManager.AppSettings["IsDevelopment"]);

        /// <inheritdoc />
        public virtual StorageAccountSettings StorageAccount => new StorageAccountSettings();
    }
}