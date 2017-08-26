using System;

using Autofac;

namespace WebJob.Functions.JobActivator
{
    /// <summary>
    /// This represents the handler entity for dependency registration to job activator.
    /// </summary>
    public class RegistrationHandler
    {
        /// <summary>
        /// Gets or sets the action to register type.
        /// </summary>
        public Action<ContainerBuilder> RegisterTypeAsInstancePerDependency { get; set; }
    }
}