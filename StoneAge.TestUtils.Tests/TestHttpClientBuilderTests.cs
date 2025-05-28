using System.Net.Http;
using System.Threading.Tasks;
using StoneAge.TestUtils;
using Xunit;

namespace StoneAge.TestUtils.Tests
{
    public class TestHttpClientBuilderTests
    {
        [Fact]
        public async Task Create_ReturnsClient_ThatReturnsPayload()
        {
            var builder = new TestHttpClientBuilder().With_Payload("{\"foo\":\"bar\"}");
            var (client, handler) = builder.Create();

            var response = await client.GetAsync("http://test");
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal("{\"foo\":\"bar\"}", content);
            Assert.NotNull(handler.RequestMessage);
            Assert.Equal("http://test/", handler.RequestMessage.RequestUri.ToString());
        }

        [Fact]
        public async Task Create_ReturnsClient_WithDefaultPayload()
        {
            var builder = new TestHttpClientBuilder();
            var (client, handler) = builder.Create();

            var response = await client.GetAsync("http://test");
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal("{}", content);
        }
    }
}