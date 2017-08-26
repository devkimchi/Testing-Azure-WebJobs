using FluentAssertions;

using Xunit;

namespace WebJob.Settings.Tests
{
    /// <summary>
    /// This represents the test entity for the <see cref="StorageAccountSettings"/> class.
    /// </summary>
    public class StorageAccountSettingsTests
    {
        /// <summary>
        /// Tests whether the property should return result or not.
        /// </summary>
        [Fact]
        public void Given_AppConfig_ConnectionString_ShouldReturn_Result()
        {
            var settings = new StorageAccountSettings();

            settings.ConnectionString.Should().StartWithEquivalent("use");
            settings.ConnectionString.Should().EndWithEquivalent("true");
        }
    }
}