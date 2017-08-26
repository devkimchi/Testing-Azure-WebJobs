using Autofac;
using Autofac.Core;

namespace WebJob.Functions.JobActivator
{
    /// <summary>
    /// This represents the activator entity for Azure WebJobs.
    /// </summary>
    public class WebJobActivator : IWebJobActivator
    {
        private readonly ContainerBuilder _builder;

        private IContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebJobActivator"/> class.
        /// </summary>
        public WebJobActivator()
        {
            this._builder = new ContainerBuilder();
        }

        /// <inheritdoc />
        public IWebJobActivator RegisterModule<TModule>(RegistrationHandler handler = null) where TModule : IModule, new()
        {
            this._builder.RegisterModule<TModule>();

            if (handler == null)
            {
                return this;
            }

            if (handler.RegisterTypeAsInstancePerDependency == null)
            {
                return this;
            }

            handler.RegisterTypeAsInstancePerDependency.Invoke(this._builder);

            return this;
        }

        /// <inheritdoc />
        public IWebJobActivator Activate()
        {
            this._container = this._builder.Build();

            return this;
        }

        /// <inheritdoc />
        public T CreateInstance<T>()
        {
            return this._container.Resolve<T>();
        }
    }
}
