namespace FeedParser
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class Program
    {
        private const string XML_FILE_PATH = @"..\..\..\SoftUniRSS.xml";
        private const string HTML_FILE_PATH = @"..\..\..\SoftUniRSS.html";

        public static void Main()
        {
            GetFile("https://softuni.bg/Feed/News");

            var softUniRss = XDocument.Load(XML_FILE_PATH);
            var softUniJsonRss = JsonConvert.SerializeObject(softUniRss);
            var softUniRssItems = JObject.Parse(softUniJsonRss)["rss"]["channel"]["item"];

            var questionTitles = softUniRssItems.Select(x => x["title"]);

            foreach (var questionTitle in questionTitles)
            {
                Console.WriteLine(questionTitle);
            }

            var items = softUniRssItems.ToList();

            var poco = items.Select(i => JsonConvert.DeserializeObject<Item>(i.ToString())).ToList();

            foreach (var p in poco)
            {
                Console.WriteLine(p);
            }

            var result = new StringBuilder();
            result.Append("<!DOCTYPE html><html><head><meta charset=\"utf-8\"></head>");

            foreach (var p in poco)
            {
                result.Append(p);
            }

            result.Append("</body></html>");
            File.WriteAllText(HTML_FILE_PATH, result.ToString());
        }

        public static void GetFile(string url)
        {
            var webClinet = new WebClient();
            webClinet.DownloadFile(url, XML_FILE_PATH);
        }

        public static string GetFileStream(string url)
        {
            using (var stream = new StreamReader(
                WebRequest.Create(url)
                .GetResponse()
                .GetResponseStream()))
            {
                return stream.ReadToEnd();
            }
        }
    }
}