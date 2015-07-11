namespace News.ConsoleClient
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Console.Write("Search: ");

            var baseUrl = "http://api.feedzilla.com/v1/articles/search.json?";
            var requester = new HttpRequester(baseUrl);

            var search = Console.ReadLine() ?? "Michel";
            var news = requester.Get(search);

            foreach (var entry in news)
            {
                Console.WriteLine(entry);
            }
        }
    }
}