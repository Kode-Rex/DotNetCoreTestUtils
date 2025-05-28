using NUnit.Framework;
using StoneAge.TestUtils;

namespace TestUtils.Tests;

public class MockOptionsTests
{
    private class TestOptions
    {
        public string? Name { get; set; }
        public int Value { get; set; }
    }

    [Test]
    public void Value_WhenAccessed_ReturnsProvidedValue()
    {
        // Arrange
        var expectedOptions = new TestOptions { Name = "Test", Value = 42 };
        var mockOptions = new MockOptions<TestOptions>(expectedOptions);

        // Act
        var result = mockOptions.Value;

        // Assert
        Assert.That(result, Is.EqualTo(expectedOptions));
        Assert.That(result.Name, Is.EqualTo("Test"));
        Assert.That(result.Value, Is.EqualTo(42));
    }
}

public class MockOptionsSnapshotTests
{
    private class TestOptions
    {
        public string? Name { get; set; }
        public int Value { get; set; }
    }

    [Test]
    public void Value_WhenAccessed_ReturnsProvidedValue()
    {
        // Arrange
        var expectedOptions = new TestOptions { Name = "Test", Value = 42 };
        var mockOptionsSnapshot = new MockOptionsSnapshot<TestOptions>(expectedOptions);

        // Act
        var result = mockOptionsSnapshot.Value;

        // Assert
        Assert.That(result, Is.EqualTo(expectedOptions));
        Assert.That(result.Name, Is.EqualTo("Test"));
        Assert.That(result.Value, Is.EqualTo(42));
    }

    [Test]
    public void Get_WhenCalled_ThrowsNotImplementedException()
    {
        // Arrange
        var options = new TestOptions();
        var mockOptionsSnapshot = new MockOptionsSnapshot<TestOptions>(options);

        // Act & Assert
        Assert.Throws<System.NotImplementedException>(() => mockOptionsSnapshot.Get("name"));
    }
} 