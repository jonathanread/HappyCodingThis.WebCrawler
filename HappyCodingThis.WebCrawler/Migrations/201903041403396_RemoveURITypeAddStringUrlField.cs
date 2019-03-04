namespace HappyCodingThis.WebCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveURITypeAddStringUrlField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RetrievedPages", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RetrievedPages", "Url");
        }
    }
}
