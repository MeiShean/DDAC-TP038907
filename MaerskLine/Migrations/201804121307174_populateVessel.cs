namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateVessel : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Vessels ( VesselName) VALUES ('Vessel_One')");
            Sql("INSERT INTO Vessels ( VesselName) VALUES ('Vessel_Two')");
            Sql("INSERT INTO Vessels ( VesselName) VALUES ('Vessel_Three')");
            Sql("INSERT INTO Vessels ( VesselName) VALUES ('Vessel_Four')");
            Sql("INSERT INTO Vessels ( VesselName) VALUES ('Vessel_Five')");
        }
        
        public override void Down()
        {
        }
    }
}
