using System.IO;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;

using Newtonsoft.Json;

using WebJob.Functions.QueueMessages;

namespace WebJob.Functions.QueueTriggers
{
    /// <summary>
    /// This represents the function entity for queue trigger.
    /// </summary>
    public class QueueTriggerFunction : FunctionBase
    {
        /// <summary>
        /// Runs the queue trigger function.
        /// </summary>
        /// <param name="message"><see cref="QueueMessage"/> instance.</param>
        /// <param name="log"><see cref="TextWriter"/> instance.</param>
        /// <returns>Returns <see cref="Task"/>.</returns>
        /// <remarks>
        /// This function will get triggered/executed when a new message is written on an Azure Queue called queue.
        /// </remarks>
        public async Task Run([QueueTrigger("queue")] QueueMessage message, TextWriter log)
        {
            await log.WriteLineAsync(JsonConvert.SerializeObject(message)).ConfigureAwait(false);
        }
    }
}
