namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusAddedForAllClassesInEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Headings", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contents", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Writers", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Status");
            DropColumn("dbo.Writers", "Status");
            DropColumn("dbo.Contents", "Status");
            DropColumn("dbo.Headings", "Status");
            DropColumn("dbo.Abouts", "Status");
        }
    }
}
