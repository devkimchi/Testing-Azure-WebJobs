using Autofac;

using FluentAssertions;

using WebJob.Functions.QueueTriggers;
using WebJob.Functions.Tests.Fixtures;
using WebJob.Settings;

using Xunit;

namespace WebJob.Functions.Tests
{
    /// <summary>
    /// This represents the test entity for <see cref="WebJobModule"/>.
    /// </summary>
    public class WebJobModuleTests : IClassFixture<WebJobModuleFixture>
    {
        private readonly WebJobModuleFixture _fixture;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebJobModuleTests"/> class.
        /// </summary>
        /// <param name="fixture"><see cref="WebJobModuleFixture"/> instance.</param>
        public WebJobModuleTests(WebJobModuleFixture fixture)
        {
            this._fixture = fixture;
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [Fact]
        public void Given_ContainerBuilder_Load_ShouldReturn_Result()
        {
            var container = this._fixture.ArrangeContainer(p => p.RegisterModule<WebJobModule>());

            var settings = container.Resolve<IWebJobSettings>();
            var function = container.Resolve<QueueTriggerFunction>();

            settings.Should().NotBeNull();
            function.Should().NotBeNull();
        }
    }
}
