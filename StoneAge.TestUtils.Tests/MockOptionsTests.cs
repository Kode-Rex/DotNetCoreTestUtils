using StoneAge.TestUtils;
using Xunit;

namespace StoneAge.TestUtils.Tests
{
    public class MockOptionsTests
    {
        private class Settings
        {
            public string Name { get; set; }
        }

        [Fact]
        public void Value_ReturnsInjectedInstance()
        {
            var settings = new Settings { Name = "Test" };
            var options = new MockOptions<Settings>(settings);

            Assert.Equal("Test", options.Value.Name);
            Assert.Same(settings, options.Value);
        }
    }
}