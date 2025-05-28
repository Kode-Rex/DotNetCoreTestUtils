using Microsoft.Extensions.Logging;
using NUnit.Framework;
using StoneAge.TestUtils;
using System.Collections.Generic;

namespace TestUtils.Tests;

public class MockLoggerTests
{
    private MockLogger<MockLoggerTests> _logger;

    [SetUp]
    public void Setup()
    {
        _logger = new MockLogger<MockLoggerTests>();
    }

    [Test]
    public void Log_WhenCalled_StoresLogEntry()
    {
        // Arrange
        var logLevel = LogLevel.Information;
        var message = "Test log message";

        // Act
        _logger.Log(logLevel, 0, message, null, (state, ex) => state.ToString());

        // Assert
        Assert.That(_logger.LogEntries.ContainsKey(logLevel), Is.True);
        Assert.That(_logger.LogEntries[logLevel], Contains.Item(message));
    }

    [Test]
    public void Fetch_Entries_For_WhenCalled_ReturnsEntriesForLevel()
    {
        // Arrange
        var logLevel = LogLevel.Warning;
        var message = "Warning message";
        _logger.Log(logLevel, 0, message, null, (state, ex) => state.ToString());

        // Act
        List<string> entries = _logger.Fetch_Entries_For(logLevel);

        // Assert
        Assert.That(entries, Contains.Item(message));
    }

    [Test]
    public void IsEnabled_Always_ReturnsTrue()
    {
        // Act & Assert
        Assert.That(_logger.IsEnabled(LogLevel.Information), Is.True);
        Assert.That(_logger.IsEnabled(LogLevel.Error), Is.True);
        Assert.That(_logger.IsEnabled(LogLevel.Debug), Is.True);
    }
} 