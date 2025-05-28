using System.Net.Http;
using System.Threading.Tasks;
using StoneAge.TestUtils;
using Xunit;

namespace StoneAge.TestUtils.Tests
{
    public class TestHttpMessageHandlerTests
    {
        [Fact]
        public async Task SendAsync_ReturnsSpecifiedPayloadsInOrder()
        {
            var handler = new TestHttpMessageHandler()
                .With_Payload("first")
                .With_Payload("second");

            var client = new HttpClient(handler);

            var resp1 = await client.GetAsync("http://one");
            var resp2 = await client.GetAsync("http://two");

            var content1 = await resp1.Content.ReadAsStringAsync();
            var content2 = await resp2.Content.ReadAsStringAsync();

            Assert.Equal("first", content1);
            Assert.Equal("second", content2);
        }

        [Fact]
        public async Task SendAsync_ReturnsDefaultPayload_WhenNoneSpecified()
        {
            var handler = new TestHttpMessageHandler();
            var client = new HttpClient(handler);

            var resp = await client.GetAsync("http://none");
            var content = await resp.Content.ReadAsStringAsync();

            Assert.Equal("{}", content);
        }

        [Fact]
        public async Task SendAsync_Sets_RequestMessage()
        {
            var handler = new TestHttpMessageHandler().With_Payload("payload");
            var client = new HttpClient(handler);

            var req = new HttpRequestMessage(HttpMethod.Get, "http://foo");
            await client.SendAsync(req);

            Assert.NotNull(handler.RequestMessage);
            Assert.Equal("http://foo/", handler.RequestMessage.RequestUri.ToString());
        }
    }
}