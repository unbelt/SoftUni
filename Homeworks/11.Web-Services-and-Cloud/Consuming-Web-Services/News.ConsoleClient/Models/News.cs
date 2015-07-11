namespace News.ConsoleClient.Models
{
    using Newtonsoft.Json;

    public class News
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        public override string ToString()
        {
            return string.Format("Title: {0} \r\n URL: {1}\r\n", Title, Url);
        }
    }
}
