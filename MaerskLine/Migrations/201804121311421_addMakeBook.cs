namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMakeBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MakeBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduleId = c.Int(nullable: false),
                        AgentId = c.String(maxLength: 128),
                        CustomerId = c.Int(nullable: false),
                        Item = c.String(),
                        Space = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AgentId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: true)
                .Index(t => t.ScheduleId)
                .Index(t => t.AgentId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MakeBooks", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.MakeBooks", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.MakeBooks", "AgentId", "dbo.AspNetUsers");
            DropIndex("dbo.MakeBooks", new[] { "CustomerId" });
            DropIndex("dbo.MakeBooks", new[] { "AgentId" });
            DropIndex("dbo.MakeBooks", new[] { "ScheduleId" });
            DropTable("dbo.MakeBooks");
        }
    }
}
