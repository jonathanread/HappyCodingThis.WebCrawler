using HappyCodingThis.WebCrawler.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCodingThis.WebCrawler.Data
{
	public class CrawlRunContext : DbContext
	{
		public CrawlRunContext() : base("name=CrawlRunContext")
		{
		}
		public DbSet<CrawlRun> CrawlRuns { get; set; }
		public DbSet<RetrievedPage> Pages { get; set; }
	}
}
