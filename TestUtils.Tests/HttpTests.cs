using NUnit.Framework;
using StoneAge.TestUtils;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestUtils.Tests;

public class HttpTests
{
    [Test]
    public void TestHttpClientBuilder_Create_ReturnsClientAndHandler()
    {
        // Arrange
        var builder = new TestHttpClientBuilder();

        // Act
        var (client, handler) = builder.Create();

        // Assert
        Assert.That(client, Is.Not.Null);
        Assert.That(handler, Is.Not.Null);
        Assert.That(client.GetType(), Is.EqualTo(typeof(HttpClient)));
        Assert.That(handler.GetType(), Is.EqualTo(typeof(TestHttpMessageHandler)));
    }

    [Test]
    public void TestHttpClientBuilder_WithPayload_SetsPayload()
    {
        // Arrange
        var expectedPayload = "{\"name\":\"test\"}";
        var builder = new TestHttpClientBuilder();

        // Act
        var (client, _) = builder.With_Payload(expectedPayload).Create();

        // Assert
        Assert.That(client, Is.Not.Null);
    }

    [Test]
    public async Task TestHttpMessageHandler_SendAsync_ReturnsResponseWithPayload()
    {
        // Arrange
        var expectedPayload = "{\"name\":\"test\"}";
        var builder = new TestHttpClientBuilder().With_Payload(expectedPayload);
        var (client, handler) = builder.Create();

        // Act
        var response = await client.GetAsync("https://example.com");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.That(response.IsSuccessStatusCode, Is.True);
        Assert.That(content, Is.EqualTo(expectedPayload));
        Assert.That(handler.RequestMessage, Is.Not.Null);
        Assert.That(handler.RequestMessage.RequestUri?.Host, Is.EqualTo("example.com"));
    }
} 