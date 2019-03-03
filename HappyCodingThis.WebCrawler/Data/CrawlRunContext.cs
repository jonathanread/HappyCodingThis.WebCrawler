namespace HappyCodingThis.WebCrawler.Data
{
	using global::HappyCodingThis.WebCrawler.Models;
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class CrawlRunContext : DbContext
	{
		// Your context has been configured to use a 'HappyCodingThis' connection string from your application's 
		// configuration file (App.config or Web.config). By default, this connection string targets the 
		// 'HappyCodingThis.WebCrawler.Data.HappyCodingThis' database on your LocalDb instance. 
		// 
		// If you wish to target a different database and/or database provider, modify the 'HappyCodingThis' 
		// connection string in the application configuration file.
		public CrawlRunContext()
		    : base("name=PageCrawler")
		{
		}

		// Add a DbSet for each entity type that you want to include in your model. For more information 
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		public virtual DbSet<CrawlRun> CrawlRuns { get; set; }
	}
}