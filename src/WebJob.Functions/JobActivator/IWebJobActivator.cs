using Autofac.Core;

using Microsoft.Azure.WebJobs.Host;

namespace WebJob.Functions.JobActivator
{
    /// <summary>
    /// This provides interfaces to the <see cref="WebJobActivator"/> class.
    /// </summary>
    public interface IWebJobActivator : IJobActivator
    {
        /// <summary>
        /// Registers a module.
        /// </summary>
        /// <typeparam name="TModule">The type of the module.</typeparam>
        /// <param name="handler"><see cref="RegistrationHandler"/> instance.</param>
        /// <returns>Returns the <see cref="IWebJobActivator"/> instance.</returns>
        IWebJobActivator RegisterModule<TModule>(RegistrationHandler handler = null) where TModule : IModule, new();

        /// <summary>
        /// Activates the job activator.
        /// </summary>
        /// <returns>Returns the <see cref="IWebJobActivator"/>.</returns>
        IWebJobActivator Activate();
    }
}