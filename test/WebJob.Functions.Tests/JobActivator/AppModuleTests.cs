using System.Reflection;

using Autofac;

using FluentAssertions;

using WebJob.Functions.JobActivator;
using WebJob.Functions.QueueTriggers;
using WebJob.Functions.Tests.Fixtures;
using WebJob.Settings;

using Xunit;

namespace WebJob.Functions.Tests.JobActivator
{
    /// <summary>
    /// This represents the test entity for <see cref="AppModule"/>.
    /// </summary>
    public class AppModuleTests : IClassFixture<AppModuleFixture>
    {
        private readonly AppModuleFixture _fixture;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppModuleTests"/> class.
        /// </summary>
        /// <param name="fixture"><see cref="AppModuleFixture"/> instance.</param>
        public AppModuleTests(AppModuleFixture fixture)
        {
            this._fixture = fixture;
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [Fact]
        public void Given_Dependencies_Load_ShouldReturn_Result()
        {
            var container = this._fixture.ArrangeContainer(p => p.RegisterModule<AppModule>());

            var settings = container.Resolve<IWebJobSettings>();
            var function = container.Resolve<QueueTriggerFunction>();

            settings.Should().NotBeNull();
            function.Should().NotBeNull();
        }
    }
}
