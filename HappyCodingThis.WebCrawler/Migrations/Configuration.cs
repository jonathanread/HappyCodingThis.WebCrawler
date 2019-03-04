namespace HappyCodingThis.WebCrawler.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HappyCodingThis.WebCrawler.Data.CrawlRunContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HappyCodingThis.WebCrawler.Data.CrawlRunContext";
        }

        protected override void Seed(HappyCodingThis.WebCrawler.Data.CrawlRunContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
