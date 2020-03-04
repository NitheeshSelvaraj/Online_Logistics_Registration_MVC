namespace Online_Logistics_Registration_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleID = c.Int(name: "Vehicle ID", nullable: false, identity: true),
                        VehicleNumber = c.String(name: "Vehicle Number", nullable: false, maxLength: 10),
                        VehicleType = c.String(name: "Vehicle Type", nullable: false),
                        StartLocation = c.String(name: "Start Location", nullable: false),
                        DestinationLocation = c.String(name: "Destination Location", nullable: false),
                        LoadWeight = c.Int(name: "Load Weight", nullable: false),
                    })
                .PrimaryKey(t => t.VehicleID)
                .Index(t => t.VehicleNumber, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vehicles", new[] { "Vehicle Number" });
            DropTable("dbo.Vehicles");
        }
    }
}
