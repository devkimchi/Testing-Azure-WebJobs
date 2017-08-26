using System;

using WebJob.Functions.JobActivator;

namespace WebJob.Functions.Tests.Fixtures
{
    /// <summary>
    /// This represents the fixture entity for job activator.
    /// </summary>
    public class JobActivatorFixture : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Arranges the <see cref="IWebJobActivator"/> instance.
        /// </summary>
        /// <returns>Returns the <see cref="IWebJobActivator"/> instance.</returns>
        public IWebJobActivator ArrangeWebJobActivator()
        {
            var activator = new WebJobActivator();

            return activator;
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

            this._disposed = true;
        }
    }
}
