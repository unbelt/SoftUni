using System.Web.Script.Serialization;

namespace Ads.ConsoleClient
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public class Ads
    {
        public static void Main()
        {
            // No major difference in time, because of the small data
            var timer = new Stopwatch();

            Console.WriteLine("---------------- 1. Show Data from Related Tables");
            timer.Start();
            GetAdsDetails();
            timer.Stop();
            //Console.WriteLine("{0} \r\nTime WITHOUT Include() at GetAdsDetails(): {1}\r\n", GetAdsDetails(), timer.Elapsed);

            /*timer.Start();
            GetAdsInfo();
            timer.Stop();
            Console.WriteLine("{0} \r\nTime WITH Include() at GetAdsInfo(): {1}\r\n", GetAdsInfo(), timer.Elapsed);

            Console.WriteLine("---------------- 2. Play with ToList()");
            timer.Start();
            GetAllActiveAds();
            timer.Stop();
            Console.WriteLine("{0} \r\nUNOPTIMIZED select GetAllActiveAds(): {1}\r\n", GetAllActiveAds(), timer.Elapsed);

            timer.Start();
            GetActiveAds();
            timer.Stop();
            Console.WriteLine("{0} \r\nOPTIMIZED select GetAllActiveAds(): {1}\r\n", GetActiveAds(), timer.Elapsed);

            Console.WriteLine(" ---------------- 3. Select Everything vs. Select Certain Columns");
            timer.Start();
            SelectAllFromAds();
            timer.Stop();
            //Console.WriteLine(SelectAllFromAds()); // Big data!
            Console.WriteLine("\r\nSelectAllFromAds(): {0}\r\n", timer.Elapsed);

            timer.Start();
            SelectAdsTitle();
            timer.Stop();
            Console.WriteLine("{0} \r\nSelectAdsTitle(): {1}\r\n", SelectAdsTitle(), timer.Elapsed);*/
        }

        public static string GetAdsDetails()
        {
            var output = new StringBuilder();

            using (var db = new AdsEntities())
            {
                var ads = (from a in db.Ads
                           join s in db.AdStatuses on a.StatusId equals s.Id
                           join c in db.Categories on a.CategoryId equals c.Id into categoryGroup
                           from c in categoryGroup.DefaultIfEmpty()
                           join t in db.Towns on a.TownId equals t.Id into townGroup
                           from t in townGroup.DefaultIfEmpty()
                           join u in db.AspNetUsers on a.OwnerId equals u.Id
                           select new { a.Title, s.Status, Category = c.Name ?? "[No category]", Town = t.Name ?? "[No town]", u.UserName }).ToList();

                foreach (var ad in ads)
                {
                    output.AppendLine(ad.ToString());
                }

                return output.ToString();
            }
        }

        public static string GetAdsInfo()
        {
            var output = new StringBuilder();

            using (var db = new AdsEntities())
            {
                var ads = db.Ads;

                foreach (var ad in ads)
                {
                    var category = "[No Category]";
                    var town = "[No Town]";

                    if (ad.Category != null)
                    {
                        category = ad.Category.Name;
                    }

                    if (ad.Town != null)
                    {
                        town = ad.Town.Name;
                    }

                    output.AppendFormat("{0} \r\nStatus: {1} \r\nCategory: {2} \r\nTown: {3} \r\nUser: {4}\r\n\r\n",
                        ad.Title, ad.AdStatus.Status, category, town, ad.AspNetUser.UserName);
                }

                return output.ToString();
            }
        }

        public static string GetAllActiveAds()
        {
            var output = new StringBuilder();

            using (var db = new AdsEntities())
            {
                var activeAds = db.Ads.ToList()
                    .Where(s => s.AdStatus.Status == "Published").ToList()
                    .OrderBy(o => o.Date)
                    .Select(x => new
                    {
                        x.Title,
                        Category = x.Category == null ? "[No Category]" : x.Category.Name,
                        Town = x.Town == null ? "[No Town]" : x.Town.Name
                    }).ToList();

                foreach (var ad in activeAds)
                {
                    output.AppendLine(ad.ToString());
                }

                return output.ToString();
            }
        }

        public static string GetActiveAds()
        {
            var output = new StringBuilder();

            using (var db = new AdsEntities())
            {
                var activeAds = from a in db.Ads
                                join c in db.Categories on a.CategoryId equals c.Id into catGroup
                                from c in catGroup.DefaultIfEmpty()
                                join t in db.Towns on a.TownId equals t.Id into townsGroup
                                from t in townsGroup.DefaultIfEmpty()
                                join s in db.AdStatuses on a.StatusId equals s.Id
                                where s.Status == "Published"
                                orderby a.Date
                                select new
                                {
                                    a.Title,
                                    Category = c.Name ?? "[No category]",
                                    Town = t.Name ?? "[No town]"
                                };


                var serializer = new JavaScriptSerializer();


                Console.WriteLine(serializer.Serialize(activeAds));

                foreach (var ad in activeAds)
                {
                    output.AppendLine(ad.ToString());
                }

                return output.ToString();
            }
        }

        public static string SelectAllFromAds()
        {
            var output = new StringBuilder();

            using (var db = new AdsEntities())
            {
                var ads = db.Ads.ToList();

                foreach (var ad in ads)
                {
                    output.AppendFormat("Id: {0} \r\nTitle: {1} \r\nText: {2} \r\nImageDataURL: {3} \r\nOwnerId: {4}" +
                                        "\r\nCategoryId: {5} \r\nTownId: {6} \r\nDate: {7} \r\nStatusId: {8}",
                        ad.Id, ad.Title, ad.Text, ad.ImageDataURL, ad.OwnerId, ad.CategoryId, ad.TownId, ad.Date, ad.StatusId);
                }

                return output.ToString();
            }
        }

        public static string SelectAdsTitle()
        {
            var output = new StringBuilder();

            using (var db = new AdsEntities())
            {
                var adsTitles = db.Ads.Select(a => a.Title).ToList();

                foreach (var title in adsTitles)
                {
                    output.AppendLine(title);
                }

                return output.ToString();
            }
        }
    }
}