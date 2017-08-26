using Microsoft.Azure.WebJobs;

using WebJob.Functions.JobActivator;

namespace WebJob.Functions.JobHostBuilder
{
    /// <summary>
    /// This represents the builder entity for WebJob host.
    /// </summary>
    public class WebJobHostBuilder : IWebJobHostBuilder
    {
        private readonly IWebJobActivator _activator;

        private JobHostConfiguration _config;
        private JobHost _host;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebJobHostBuilder"/> class.
        /// </summary>
        public WebJobHostBuilder()
        {
            this._activator = new WebJobActivator().RegisterModule<AppModule>().Activate();
        }

        /// <inheritdoc />
        public bool IsRunning { get; set; }

        /// <inheritdoc />
        public void BuildHost()
        {
            this._config = new JobHostConfiguration() { JobActivator = this._activator }
                               .UseDevelopmentSettingsIfNecessary();

            this._host = new JobHost(this._config);
        }

        /// <inheritdoc />
        public void RunAndBlock()
        {
            // The following code ensures that the WebJob will be running continuously
            this._host.RunAndBlock();
        }
    }
}