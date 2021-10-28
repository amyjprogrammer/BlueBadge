namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PollChoice1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Response",
                c => new
                    {
                        ResponseId = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(),
                        PollId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResponseId)
                .ForeignKey("dbo.PollChoice", t => t.PollId, cascadeDelete: true)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .Index(t => t.QuestionId)
                .Index(t => t.PollId);
            
            AddColumn("dbo.PollChoice", "Choice", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Response", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Response", "PollId", "dbo.PollChoice");
            DropIndex("dbo.Response", new[] { "PollId" });
            DropIndex("dbo.Response", new[] { "QuestionId" });
            DropColumn("dbo.PollChoice", "Choice");
            DropTable("dbo.Response");
        }
    }
}
