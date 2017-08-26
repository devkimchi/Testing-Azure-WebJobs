using System;
using System.IO;
using System.Threading.Tasks;

using Moq;

using WebJob.Functions.QueueTriggers;

namespace WebJob.Functions.Tests.Fixtures
{
    /// <summary>
    /// This represents the fixture entity for queue trigger functions.
    /// </summary>
    public class QueueTriggerFixture : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Arranges a new instance of the <see cref="QueueTriggerFunction"/> class.
        /// </summary>
        /// <param name="log"><see cref="TextWriter"/> instance.</param>
        /// <returns>Returns the <see cref="QueueTriggerFunction"/> instance.</returns>
        public QueueTriggerFunction ArrangeQueueTriggerFunction(out Mock<TextWriter> log)
        {
            log = new Mock<TextWriter>();

            var function = new QueueTriggerFunction();

            return function;
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
