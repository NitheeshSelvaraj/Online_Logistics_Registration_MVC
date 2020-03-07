namespace Online_Logistics_Registration_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 300),
                        UserName = c.String(nullable: false, maxLength: 7),
                        Password = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.MobileNumber, unique: true)
                .Index(t => t.Email, unique: true)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleID = c.Int(name: "Vehicle ID", nullable: false, identity: true),
                        VehicleNumber = c.String(name: "Vehicle Number", nullable: false, maxLength: 10),
                        VehicleType = c.Int(name: "Vehicle Type", nullable: false),
                        StartLocation = c.String(name: "Start Location", nullable: false),
                        DestinationLocation = c.String(name: "Destination Location", nullable: false),
                        LoadWeight = c.Int(name: "Load Weight", nullable: false),
                    })
                .PrimaryKey(t => t.VehicleID)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleType, cascadeDelete: true)
                .Index(t => t.VehicleNumber, unique: true)
                .Index(t => t.VehicleType);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VehicleTypeID = c.Int(name: "Vehicle Type ID", nullable: false, identity: true),
                        VehicleType = c.String(name: "Vehicle Type", nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.VehicleTypeID)
                .Index(t => t.VehicleType, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Vehicle Type", "dbo.VehicleTypes");
            DropIndex("dbo.VehicleTypes", new[] { "Vehicle Type" });
            DropIndex("dbo.Vehicles", new[] { "Vehicle Type" });
            DropIndex("dbo.Vehicles", new[] { "Vehicle Number" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "MobileNumber" });
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Users");
        }
    }
}
