namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class servicepollchoice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Email",
                c => new
                    {
                        EmailId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email_EmailId = c.Int(),
                    })
                .PrimaryKey(t => t.EmailId)
                .ForeignKey("dbo.Email", t => t.Email_EmailId)
                .Index(t => t.Email_EmailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Email", "Email_EmailId", "dbo.Email");
            DropIndex("dbo.Email", new[] { "Email_EmailId" });
            DropTable("dbo.Email");
        }
    }
}
