using Autofac;

using FluentAssertions;

using WebJob.Functions.JobActivator;
using WebJob.Functions.Tests.Fixtures;

using Xunit;

namespace WebJob.Functions.Tests.JobActivator
{
    /// <summary>
    /// This represents the test entity for the <see cref="WebJobActivator"/> class.
    /// </summary>
    public class WebJobActivatorTests : IClassFixture<JobActivatorFixture>
    {
        private readonly JobActivatorFixture _fixture;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebJobActivatorTests"/> class.
        /// </summary>
        /// <param name="fixture"><see cref="JobActivatorFixture"/> instance.</param>
        public WebJobActivatorTests(JobActivatorFixture fixture)
        {
            this._fixture = fixture;
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [Fact]
        public void Given_Handler_RegisterModule_ShouldReturn_Result()
        {
            var handler = new RegistrationHandler()
                              {
                                  RegisterTypeAsInstancePerDependency = p => p.RegisterType<FooFunction>()
                                                                              .As<IFooFunction>()
                                                                              .InstancePerDependency()
                              };
            var activator = this._fixture.ArrangeWebJobActivator()
                                         .RegisterModule<AppModule>(handler)
                                         .Activate();

            var instance = activator.CreateInstance<IFooFunction>();

            instance.Should().BeOfType<FooFunction>().And.BeAssignableTo<IFooFunction>();
        }
    }
}
