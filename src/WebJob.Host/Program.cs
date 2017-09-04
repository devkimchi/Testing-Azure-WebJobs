using Aliencube.WebJobActivator.Autofac;
using Aliencube.WebJobActivator.Core;

using WebJob.Functions;

namespace WebJob.Host
{
    /// <summary>
    /// This represents the entry point of the Azure WebJobs instance.
    /// </summary>
    /// <remarks>
    /// To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    /// </remarks>
    public static class Program
    {
        /// <summary>
        /// Gets or sets the <see cref="IJobHostBuilder"/> instance.
        /// </summary>
        public static IJobHostBuilder WebJobHost { get; set; } = new AutofacJobHostBuilder(new WebJobModule())
                                                                     .AddConfiguration(p => p.UseDevelopmentSettingsIfNecessary());

        /// <summary>
        /// Runs the Azure WebJob instance.
        /// </summary>
        /// <remarks>
        /// Please set the following connection strings in app.config for this WebJob to run: AzureWebJobsDashboard and AzureWebJobsStorage
        /// </remarks>
        public static void Main()
        {
            WebJobHost.BuildHost();
            WebJobHost.IsRunning = true;
            WebJobHost.RunAndBlock();
        }
    }
}
