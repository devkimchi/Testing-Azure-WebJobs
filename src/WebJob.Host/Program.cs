using WebJob.Functions.JobHostBuilder;

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
        /// Gets or sets the <see cref="IWebJobHostBuilder"/> instance.
        /// </summary>
        public static IWebJobHostBuilder WebJobHost { get; set; } = new WebJobHostBuilder();

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
