namespace WebJob.Functions.JobHostBuilder
{
    /// <summary>
    /// This provides interfaces to the <see cref="WebJobHostBuilder"/> class.
    /// </summary>
    public interface IWebJobHostBuilder
    {
        /// <summary>
        /// Gets or sets a value indicating whether the WebJob host is up and running.
        /// </summary>
        bool IsRunning { get; set; }

        /// <summary>
        /// Builds a new WebJob host instance.
        /// </summary>
        void BuildHost();

        /// <summary>
        /// Runs the WebJob host instance and blocks the thread.
        /// </summary>
        void RunAndBlock();
    }
}