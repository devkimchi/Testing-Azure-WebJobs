using System;

using WebJob.Settings;

namespace WebJob.Functions
{
    /// <summary>
    /// This represents the base function entity.
    /// </summary>
    public abstract class FunctionBase : IFunction
    {
        private bool _disposed;

        /// <summary>
        /// Gets the <see cref="IWebJobSettings"/> instance.
        /// </summary>
        protected IWebJobSettings WebJobSettings { get; private set; }

        /// <summary>
        /// Sets the <see cref="IWebJobSettings"/> instance.
        /// </summary>
        /// <param name="settings"><see cref="IWebJobSettings"/> instance.</param>
        public void SetWebJobSettings(IWebJobSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            this.WebJobSettings = settings;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">A value that determines whether TODO.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            if (disposing)
            {
                this.ReleaseManagedResources();
            }

            this.ReleaseUnmanagedResources();

            this._disposed = true;
        }

        /// <summary>
        /// Releases managed resources during the disposing event.
        /// </summary>
        protected virtual void ReleaseManagedResources()
        {
            // Release managed resources here.
        }

        /// <summary>
        /// Releases unmanaged resources during the disposing event.
        /// </summary>
        protected virtual void ReleaseUnmanagedResources()
        {
            // Release unmanaged resources here.
        }
    }
}