namespace HappyCodingThis.WebCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChngigRelationShips : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RetrievedPages", "ParentId", "dbo.RetrievedPages");
            DropForeignKey("dbo.RetrievedPages", "CrawlRunID", "dbo.CrawlRuns");
            DropIndex("dbo.RetrievedPages", new[] { "ParentId" });
            DropPrimaryKey("dbo.CrawlRuns");
            DropPrimaryKey("dbo.RetrievedPages");
            AddColumn("dbo.CrawlRuns", "CrawlRunId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.RetrievedPages", "RetrievedPageID", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.RetrievedPages", "ParentPageID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.CrawlRuns", "CrawlRunId");
            AddPrimaryKey("dbo.RetrievedPages", "RetrievedPageID");
            AddForeignKey("dbo.RetrievedPages", "CrawlRunID", "dbo.CrawlRuns", "CrawlRunId", cascadeDelete: true);
            DropColumn("dbo.CrawlRuns", "Id");
            DropColumn("dbo.RetrievedPages", "Id");
            DropColumn("dbo.RetrievedPages", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RetrievedPages", "ParentId", c => c.Guid(nullable: false));
            AddColumn("dbo.RetrievedPages", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.CrawlRuns", "Id", c => c.Guid(nullable: false, identity: true));
            DropForeignKey("dbo.RetrievedPages", "CrawlRunID", "dbo.CrawlRuns");
            DropPrimaryKey("dbo.RetrievedPages");
            DropPrimaryKey("dbo.CrawlRuns");
            DropColumn("dbo.RetrievedPages", "ParentPageID");
            DropColumn("dbo.RetrievedPages", "RetrievedPageID");
            DropColumn("dbo.CrawlRuns", "CrawlRunId");
            AddPrimaryKey("dbo.RetrievedPages", "Id");
            AddPrimaryKey("dbo.CrawlRuns", "Id");
            CreateIndex("dbo.RetrievedPages", "ParentId");
            AddForeignKey("dbo.RetrievedPages", "CrawlRunID", "dbo.CrawlRuns", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RetrievedPages", "ParentId", "dbo.RetrievedPages", "Id");
        }
    }
}
