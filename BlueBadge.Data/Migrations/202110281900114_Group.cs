namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Group : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Email", "Email_EmailId", "dbo.Email");
            DropForeignKey("dbo.Response", "QuestionId", "dbo.Question");
            DropIndex("dbo.Email", new[] { "Email_EmailId" });
            DropIndex("dbo.Response", new[] { "QuestionId" });
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false),
                        QuestionId = c.Int(),
                        EmailId = c.Int(),
                        CustomerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.Email", t => t.EmailId)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .Index(t => t.QuestionId)
                .Index(t => t.EmailId);
            
            AddColumn("dbo.Email", "EmailAddress", c => c.String());
            DropColumn("dbo.Email", "Email_EmailId");
            DropColumn("dbo.Response", "QuestionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Response", "QuestionId", c => c.Int());
            AddColumn("dbo.Email", "Email_EmailId", c => c.Int());
            DropForeignKey("dbo.Group", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Group", "EmailId", "dbo.Email");
            DropIndex("dbo.Group", new[] { "EmailId" });
            DropIndex("dbo.Group", new[] { "QuestionId" });
            DropColumn("dbo.Email", "EmailAddress");
            DropTable("dbo.Group");
            CreateIndex("dbo.Response", "QuestionId");
            CreateIndex("dbo.Email", "Email_EmailId");
            AddForeignKey("dbo.Response", "QuestionId", "dbo.Question", "QuestionId");
            AddForeignKey("dbo.Email", "Email_EmailId", "dbo.Email", "EmailId");
        }
    }
}
