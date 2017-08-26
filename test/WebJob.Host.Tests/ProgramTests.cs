﻿using FluentAssertions;

using Moq;

using WebJob.Functions.JobHostBuilder;

using Xunit;

namespace WebJob.Host.Tests
{
    /// <summary>
    /// This represents the test entity for the WebJob host.
    /// </summary>
    public class ProgramTests
    {
        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [Fact]
        public void Given_WebJobHostBuilder_Main_ShouldReturn_Result()
        {
            var builder = new Mock<IWebJobHostBuilder>();
            builder.SetupProperty(p => p.IsRunning);

            Program.WebJobHost = builder.Object;
            Program.Main();

            builder.Object.IsRunning.Should().BeTrue();
        }
    }
}
