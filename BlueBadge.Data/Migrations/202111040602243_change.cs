namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PollChoice", "Response_ResponseId", c => c.Int());
            AddColumn("dbo.Response", "Selected", c => c.Int(nullable: false));
            CreateIndex("dbo.PollChoice", "Response_ResponseId");
            AddForeignKey("dbo.PollChoice", "Response_ResponseId", "dbo.Response", "ResponseId");
            DropColumn("dbo.Response", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Response", "Count", c => c.Int(nullable: false));
            DropForeignKey("dbo.PollChoice", "Response_ResponseId", "dbo.Response");
            DropIndex("dbo.PollChoice", new[] { "Response_ResponseId" });
            DropColumn("dbo.Response", "Selected");
            DropColumn("dbo.PollChoice", "Response_ResponseId");
        }
    }
}
