namespace HappyCodingThis.WebCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CrawlRuns",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Elapsed = c.Time(nullable: false, precision: 7),
                        RootUrl = c.String(),
                        ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RetrievedPages",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ParentId = c.Guid(nullable: false),
                        CrawlRunID = c.Guid(nullable: false),
                        PageTitle = c.String(),
                        Path = c.String(),
                        ParentPath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RetrievedPages", t => t.ParentId)
                .ForeignKey("dbo.CrawlRuns", t => t.CrawlRunID, cascadeDelete: true)
                .Index(t => t.ParentId)
                .Index(t => t.CrawlRunID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RetrievedPages", "CrawlRunID", "dbo.CrawlRuns");
            DropForeignKey("dbo.RetrievedPages", "ParentId", "dbo.RetrievedPages");
            DropIndex("dbo.RetrievedPages", new[] { "CrawlRunID" });
            DropIndex("dbo.RetrievedPages", new[] { "ParentId" });
            DropTable("dbo.RetrievedPages");
            DropTable("dbo.CrawlRuns");
        }
    }
}
