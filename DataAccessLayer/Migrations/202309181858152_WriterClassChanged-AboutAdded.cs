﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WriterClassChangedAboutAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "About", c => c.String(maxLength: 100));
            AlterColumn("dbo.Writers", "Password", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "Password", c => c.String(maxLength: 20));
            DropColumn("dbo.Writers", "About");
        }
    }
}
