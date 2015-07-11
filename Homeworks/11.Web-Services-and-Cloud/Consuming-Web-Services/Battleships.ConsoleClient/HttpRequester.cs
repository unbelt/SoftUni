using System.Net;

namespace Battleships.ConsoleClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using Newtonsoft.Json;

    public class HttpRequester
    {
        private string baseUrl;
        private HttpClient client;

        public HttpRequester(string baseUrl)
        {
            this.baseUrl = baseUrl;
            this.client = new HttpClient();
        }

        public T Get<T>(string serviceUrl, string mediaType = "Application/Json")
        {
            var request = HttpRequestMessage(serviceUrl, mediaType, HttpMethod.Get);

            var response = client.SendAsync(request).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(result);
        }

        public HttpResponseMessage Post(string serviceUrl, object data, string mediaType = "Application/Json")
        {
            var request = HttpRequestMessage(serviceUrl, mediaType, HttpMethod.Post);

            request.Content = new StringContent(JsonConvert.SerializeObject(data));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);

            var response = client.SendAsync(request).Result;
            return response;
        }

        private HttpRequestMessage HttpRequestMessage(string serviceUrl, string mediaType, HttpMethod method)
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(string.Concat(this.baseUrl, serviceUrl)),
                Headers = { Accept = { new MediaTypeWithQualityHeaderValue(mediaType) } },
                Method = method
            };

            return request;
        }
    }
}