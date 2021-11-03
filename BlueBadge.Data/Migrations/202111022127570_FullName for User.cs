namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullNameforUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "FullName", c => c.String(maxLength: 128));
            AddColumn("dbo.ApplicationUser", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.ApplicationUser", "LastName", c => c.String(nullable: false));
            CreateIndex("dbo.Question", "FullName");
            AddForeignKey("dbo.Question", "FullName", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "FullName", "dbo.ApplicationUser");
            DropIndex("dbo.Question", new[] { "FullName" });
            DropColumn("dbo.ApplicationUser", "LastName");
            DropColumn("dbo.ApplicationUser", "FirstName");
            DropColumn("dbo.Question", "FullName");
        }
    }
}
