using System;
using StoneAge.TestUtils;
using Xunit;

namespace StoneAge.TestUtils.Tests
{
    public class MockOptionsSnapshotTests
    {
        private class Config
        {
            public int Value { get; set; }
        }

        [Fact]
        public void Value_ReturnsInjectedInstance()
        {
            var config = new Config { Value = 123 };
            var snapshot = new MockOptionsSnapshot<Config>(config);

            Assert.Equal(123, snapshot.Value.Value);
            Assert.Same(config, snapshot.Value);
        }

        [Fact]
        public void Get_ThrowsNotImplementedException()
        {
            var config = new Config();
            var snapshot = new MockOptionsSnapshot<Config>(config);

            Assert.Throws<NotImplementedException>(() => snapshot.Get("any"));
        }
    }
}