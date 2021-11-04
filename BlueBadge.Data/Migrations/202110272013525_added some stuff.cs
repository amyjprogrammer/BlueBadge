namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsomestuff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PollChoice", "PollChoice_PollId", "dbo.PollChoice");
            DropIndex("dbo.PollChoice", new[] { "PollChoice_PollId" });
            DropColumn("dbo.PollChoice", "PollChoice_PollId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PollChoice", "PollChoice_PollId", c => c.Int());
            CreateIndex("dbo.PollChoice", "PollChoice_PollId");
            AddForeignKey("dbo.PollChoice", "PollChoice_PollId", "dbo.PollChoice", "PollId");
        }
    }
}
