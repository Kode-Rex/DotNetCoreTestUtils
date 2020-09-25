using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace StoneAge.TestUtils
{
    public class TestHttpClientBuilder
    {
        private string _payload;

        public TestHttpClientBuilder()
        {
            _payload = "{}";
        }

        public TestHttpClientBuilder With_Payload(string payload)
        {
            _payload = payload;
            return this;
        }

        public (HttpClient,TestHttpMessageHandler) Create()
        {
            var handler = new TestHttpMessageHandler()
                                .With_Payload(_payload);

            return (new HttpClient(handler), handler);
        }
    }
}
