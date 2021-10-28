namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Email : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Email", "FirstName", c => c.String());
            AlterColumn("dbo.Email", "LastName", c => c.String());
            AlterColumn("dbo.Email", "EmailAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Email", "EmailAddress", c => c.String());
            AlterColumn("dbo.Email", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Email", "FirstName", c => c.String(nullable: false));
        }
    }
}
