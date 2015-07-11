namespace News.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using Newtonsoft.Json.Linq;

    public class HttpRequester
    {
        private string baseUrl;
        private HttpClient client;

        public HttpRequester(string baseUrl)
        {
            this.baseUrl = baseUrl;
            this.client = new HttpClient();
        }

        public IEnumerable<Models.News> Get(string serviceUrl, string mediaType = "Application/Json")
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(string.Concat(this.baseUrl, serviceUrl)),
                Headers = {Accept = {new MediaTypeWithQualityHeaderValue(mediaType)}},
                Method = HttpMethod.Get
            };

            var response = client.SendAsync(request).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var articles = JObject.Parse(result)["articles"].Select(x => x.ToObject<Models.News>());

            return articles;
        }
    }
}