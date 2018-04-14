namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSchedule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VesselId = c.Int(nullable: false),
                        LoadPort = c.String(nullable: false),
                        DischargePort = c.String(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        ArrivedDate = c.DateTime(nullable: false),
                        TransitTime = c.Int(nullable: false),
                        AvailableSpace = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vessels", t => t.VesselId, cascadeDelete: true)
                .Index(t => t.VesselId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "VesselId", "dbo.Vessels");
            DropIndex("dbo.Schedules", new[] { "VesselId" });
            DropTable("dbo.Schedules");
        }
    }
}
