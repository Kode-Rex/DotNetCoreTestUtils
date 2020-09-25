using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoneAge.TestUtils
{
    internal class TestHttpMessageHandler : HttpMessageHandler
    {
        private readonly List<string> _urlPayload;
        private int _requestCount;

        public HttpRequestMessage RequestMessage { get; set; }

        internal TestHttpMessageHandler()
        {
            _urlPayload = new List<string>();
            _requestCount = 0;
        }

        internal TestHttpMessageHandler With_Payload(string payload)
        {
            _urlPayload.Add(payload);
            return this;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {
            RequestMessage = request;

            var payload = Set_Payload_For_Request();

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(payload)
            };

            _requestCount++;
            return await Task.FromResult(responseMessage);
        }

        private string Set_Payload_For_Request()
        {
            var payload = "{}";
            if (_requestCount < _urlPayload.Count)
            {
                payload = _urlPayload[_requestCount];
            }

            return payload;
        }
    }
}
