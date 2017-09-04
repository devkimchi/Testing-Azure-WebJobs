using System;

using Autofac;

namespace WebJob.Functions.Tests.Fixtures
{
    /// <summary>
    /// This represents the fixture entity for the <see cref="WebJobModuleTests"/> class.
    /// </summary>
    public class WebJobModuleFixture : IDisposable
    {
        private IContainer _container;
        private bool _disposed;

        /// <summary>
        /// Arranges the <see cref="IContainer"/> instance.
        /// </summary>
        /// <param name="action">Action for <see cref="ContainerBuilder"/> instance.</param>
        /// <returns>Returns the <see cref="IContainer"/> instance.</returns>
        public IContainer ArrangeContainer(Action<ContainerBuilder> action)
        {
            var builder = new ContainerBuilder();

            action.Invoke(builder);

            this._container = builder.Build();

            return this._container;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            if (this._container != null)
            {
                this._container.Dispose();
            }

            this._disposed = true;
        }
    }
}
