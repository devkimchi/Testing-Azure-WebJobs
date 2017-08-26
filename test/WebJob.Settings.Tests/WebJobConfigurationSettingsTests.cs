using FluentAssertions;

using Xunit;

namespace WebJob.Settings.Tests
{
    /// <summary>
    /// This represents the test entity for the <see cref="WebJobConfigurationSettings"/> class.
    /// </summary>
    public class WebJobConfigurationSettingsTests
    {
        /// <summary>
        /// Tests whether the property should return result or not.
        /// </summary>
        [Fact]
        public void Given_AppConfig_IsDevelopment_ShouldReturn_Result()
        {
            var settings = new WebJobConfigurationSettings();

            settings.IsDevelopment.Should().BeTrue();
        }
    }
}
