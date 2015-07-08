namespace FeedParser
{
    using System;

    using Newtonsoft.Json;

    public class Item
    {
        public Guid Guid { get; set; }

        public string Link { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [JsonProperty("a10:updated")]
        public DateTime Updated { get; set; }

        public override string ToString()
        {
            return string.Format("{0} \r\nLink: {1} \r\nTitle: {2} \r\nDescription: {3} \r\nUpdated: {4}\r\n",
                this.Guid, this.Link, this.Title, this.Description, this.Updated);
        }
    }
}