using System.IO;
using System.Threading.Tasks;

using FluentAssertions;

using Moq;

using Newtonsoft.Json;

using WebJob.Functions.QueueMessages;
using WebJob.Functions.QueueTriggers;
using WebJob.Functions.Tests.Fixtures;

using Xunit;

namespace WebJob.Functions.Tests.QueueTriggers
{
    /// <summary>
    /// This represents the test entity for the <see cref="QueueTriggerFunction"/> class.
    /// </summary>
    public class QueueTriggerFunctionTests : IClassFixture<QueueTriggerFixture>
    {
        private readonly QueueTriggerFixture _fixture;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueTriggerFunctionTests"/> class.
        /// </summary>
        /// <param name="fixture"><see cref="QueueTriggerFixture"/> instance.</param>
        public QueueTriggerFunctionTests(QueueTriggerFixture fixture)
        {
            this._fixture = fixture;
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        /// <param name="message">Queue message.</param>
        [Theory]
        [InlineData("lorem ipsum")]
        public async void Given_QueueMessage_Run_ShouldReturn_Result(string message)
        {
            var result = string.Empty;

            var function = this._fixture.ArrangeQueueTriggerFunction(out Mock<TextWriter> log);

            log.Setup(p => p.WriteLineAsync(It.IsAny<string>()))
               .Returns(Task.CompletedTask)
               .Callback<string>(p => result = p);

            var msg = new QueueMessage() { Message = message };

            await function.Run(msg, log.Object).ConfigureAwait(false);

            result.Should().BeEquivalentTo(JsonConvert.SerializeObject(msg));
        }
    }
}
