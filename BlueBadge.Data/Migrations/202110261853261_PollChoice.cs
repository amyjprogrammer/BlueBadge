namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PollChoice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PollChoice",
                c => new
                    {
                        PollId = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        PollChoice_PollId = c.Int(),
                    })
                .PrimaryKey(t => t.PollId)
                .ForeignKey("dbo.PollChoice", t => t.PollChoice_PollId)
                .ForeignKey("dbo.Question", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.PollChoice_PollId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PollChoice", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.PollChoice", "PollChoice_PollId", "dbo.PollChoice");
            DropIndex("dbo.PollChoice", new[] { "PollChoice_PollId" });
            DropIndex("dbo.PollChoice", new[] { "QuestionId" });
            DropTable("dbo.PollChoice");
        }
    }
}
