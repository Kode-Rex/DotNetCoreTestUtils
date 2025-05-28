using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using StoneAge.TestUtils;
using Xunit;

namespace StoneAge.TestUtils.Tests
{
    public class MockLoggerTests
    {
        [Fact]
        public void Log_AddsEntry_ForGivenLogLevel()
        {
            var logger = new MockLogger<string>();
            logger.Log(LogLevel.Information, new EventId(), "Test message", null, (s, e) => s);

            Assert.Contains("Test message", logger.LogEntries[LogLevel.Information]);
        }

        [Fact]
        public void IsEnabled_AlwaysReturnsTrue()
        {
            var logger = new MockLogger<string>();
            Assert.True(logger.IsEnabled(LogLevel.Debug));
            Assert.True(logger.IsEnabled(LogLevel.Warning));
        }

        [Fact]
        public void Fetch_Entries_For_ReturnsEntries()
        {
            var logger = new MockLogger<string>();
            logger.Log(LogLevel.Error, new EventId(), "Error logged", null, (s, e) => s);

            var entries = logger.Fetch_Entries_For(LogLevel.Error);
            Assert.Single(entries);
            Assert.Equal("Error logged", entries.First());
        }

        [Fact]
        public void BeginScope_ThrowsNotImplementedException()
        {
            var logger = new MockLogger<string>();
            Assert.Throws<NotImplementedException>(() => logger.BeginScope("scope"));
        }
    }
}