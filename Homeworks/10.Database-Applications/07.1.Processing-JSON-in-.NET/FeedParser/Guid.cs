namespace FeedParser
{
    using Newtonsoft.Json;

    public class Guid
    {
        [JsonProperty("@isPermaLink")]
        public bool IsPermaLink { get; set; }

        [JsonProperty("#text")]
        public int Text { get; set; }

        public override string ToString()
        {
            return string.Format("isPermaLink: {0} \r\nText: {1}", this.IsPermaLink, this.Text);
        }
    }
}