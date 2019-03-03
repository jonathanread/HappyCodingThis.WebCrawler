using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyCodingThis.WebCrawler;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Lets Crawl The World!");
			var validUri = GetUriToCrawl();

			Crawler crawler = new Crawler(validUri);
			crawler.Crawl();

			Console.Write(crawler.HasError ? crawler.ErrorMessage : crawler.Message);
			Console.ReadKey(true);
			
		}

		private static Uri GetUriToCrawl(bool secondTry = false)
		{

			Console.WriteLine(!secondTry ? "What starting URL would you like to Crawl?" : "Ooops, that does not look like a correct URL, please supply a valid absolute URL.");
			string uri = Console.ReadLine();
			var validUri = Uri.TryCreate(uri, UriKind.Absolute, out Uri parsedUri);
			if (!validUri && (parsedUri.Scheme == Uri.UriSchemeHttp || parsedUri.Scheme == Uri.UriSchemeHttps))
			{
				GetUriToCrawl(true);
			}

			return parsedUri;
		}
	}
}
