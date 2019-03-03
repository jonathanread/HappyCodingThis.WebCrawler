using Abot.Crawler;
using Abot.Poco;
using HappyCodingThis.WebCrawler.Models;
using HappyCodingThis.WebCrawler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCodingThis.WebCrawler
{
	public class Crawler
	{
		#region Constructors
		public Crawler()
		{
			HasError = false;
			Pages = new List<RetrievedPage>();
			InitCrawlerConfig();
			crawlRunContext = new CrawlRunContext();
		}

		public Crawler(Uri uri)
		{
			HasError = false;
			Pages = new List<RetrievedPage>();
			WebsiteToCrawl = uri;

			InitCrawlerConfig();
			crawlRunContext = new CrawlRunContext();

		}
		#endregion Constructors

		#region Public Methods
		public void Crawl()
		{
			PoliteWebCrawler crawler = new PoliteWebCrawler(crawlConfig, null, null, null, null, null, null, null, null);
			crawler.PageCrawlStartingAsync += Crawler_ProcessPageCrawlStarting;
			crawler.PageCrawlCompletedAsync += Crawler_ProcessPageCrawlCompleted;
			crawler.PageCrawlDisallowedAsync += Crawler_PageCrawlDisallowed;
			crawler.PageLinksCrawlDisallowedAsync += Crawler_PageLinksCrawlDisallowed;

			CrawlResult result = crawler.Crawl(WebsiteToCrawl); //This is synchronous, it will not go to the next line until the crawl has completed
			PagesCrawled = result.CrawlContext.CrawledCount;

			if (result.ErrorOccurred)
			{
				HasError = true;
				ErrorMessage = $"Crawl of {result.RootUri.AbsoluteUri} completed with error: {result.ErrorException.Message}";
			}
			else
			{
				Message = $"Crawl of {result.RootUri.AbsoluteUri} completed without error and crawled {PagesCrawled} pages and {Pages.Count} unique pages.";
			}

			var crawlRun = new CrawlRun() { Pages = Pages, Elapsed = result.Elapsed, RootUrl = result.RootUri.AbsoluteUri, ErrorMessage = result.ErrorOccurred == true ? result.ErrorException : null };
			crawlRunContext.CrawlRuns.Add(crawlRun);
			crawlRunContext.SaveChanges();

		}
		#endregion Public Methods

		#region Private Methods
		private void Crawler_PageLinksCrawlDisallowed(object sender, PageLinksCrawlDisallowedArgs e)
		{
			Console.WriteLine($"Page Crawl Disallowed, Page: {e.CrawledPage.Uri}, Reason: {e.DisallowedReason}");
		}

		private void Crawler_PageCrawlDisallowed(object sender, PageCrawlDisallowedArgs e)
		{
			Console.WriteLine($"Page Crawl Disallowed, Page: {e.PageToCrawl.Uri}, Reason: {e.DisallowedReason}");
		}

		private void Crawler_ProcessPageCrawlCompleted(object sender, PageCrawlCompletedArgs e)
		{
			var requestStarted = e.CrawledPage.RequestStarted;
			var requestCompleted = e.CrawledPage.RequestCompleted;
			var doc = e.CrawledPage.AngleSharpHtmlDocument;
			var title = doc.Title;
			var uri = e.CrawledPage.Uri;
			var path = $"{uri.Scheme}{Uri.SchemeDelimiter}{uri.Authority}{uri.AbsolutePath}";
			var parentUri = e.CrawledPage.ParentUri;
			var parentPath = $"{parentUri.Scheme}{Uri.SchemeDelimiter}{parentUri.Authority}{parentUri.AbsolutePath}";
			if (!Pages.Any(rp => rp.PageTitle == title || (rp.Path == path && rp.ParentPath == parentPath)))
			{
				Pages.Add(new RetrievedPage() { HtmlDoc = doc, PageTitle = title, Uri = uri, Path = path, ParentPath = parentPath });
			}
			Console.WriteLine($"Page Crawled: {e.CrawledPage.Uri} in {(requestCompleted - requestStarted).TotalSeconds} seconds");
		}

		private void Crawler_ProcessPageCrawlStarting(object sender, PageCrawlStartingArgs e)
		{
			Console.WriteLine($"Page to Crawl: {e.PageToCrawl}");
		}

		private void InitCrawlerConfig()
		{
			crawlConfig = new CrawlConfiguration
			{
				CrawlTimeoutSeconds = 100,
				MaxConcurrentThreads = 10,
				MaxPagesToCrawl = 1000
			};
		}
		#endregion Private Methods

		#region Public Properties
		public Uri WebsiteToCrawl { get; set; }
		public int PagesCrawled { get; set; }
		public string ErrorMessage { get; set; }
		public string Message { get; set; }
		public List<RetrievedPage> Pages { get; set; }
		public bool HasError { get; set; }
		#endregion Public Properties

		#region Private Properties
		private CrawlConfiguration crawlConfig;
		private CrawlRunContext crawlRunContext;

		#endregion Private Properties
	}
}
