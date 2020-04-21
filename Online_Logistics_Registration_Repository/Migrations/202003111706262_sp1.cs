namespace Online_Logistics_Registration_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sp1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Vehicles", name: "Vehicle ID", newName: "Vehicle_ID");
            RenameColumn(table: "dbo.Vehicles", name: "Vehicle Number", newName: "Vehicle_Number");
            RenameColumn(table: "dbo.Vehicles", name: "Vehicle Type", newName: "Vehicle_Type");
            RenameColumn(table: "dbo.Vehicles", name: "Start Location", newName: "Start_Location");
            RenameColumn(table: "dbo.Vehicles", name: "Destination Location", newName: "Destination_Location");
            RenameColumn(table: "dbo.Vehicles", name: "Load Weight", newName: "Load_Weight");
            RenameIndex(table: "dbo.Vehicles", name: "IX_Vehicle Type", newName: "IX_Vehicle_Type");
            CreateStoredProcedure(
                "dbo.Vehicle_Insert",
                p => new
                    {
                        Vehicle_Number = p.String(maxLength: 10),
                        Vehicle_Type = p.Int(),
                        Start_Location = p.String(),
                        Destination_Location = p.String(),
                        Load_Weight = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Vehicles]([Vehicle_Number], [Vehicle_Type], [Start_Location], [Destination_Location], [Load_Weight])
                      VALUES (@Vehicle_Number, @Vehicle_Type, @Start_Location, @Destination_Location, @Load_Weight)
                      
                      DECLARE @Vehicle_ID int
                      SELECT @Vehicle_ID = [Vehicle_ID]
                      FROM [dbo].[Vehicles]
                      WHERE @@ROWCOUNT > 0 AND [Vehicle_ID] = scope_identity()
                      
                      SELECT t0.[Vehicle_ID]
                      FROM [dbo].[Vehicles] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Vehicle_ID] = @Vehicle_ID"
            );
            
            CreateStoredProcedure(
                "dbo.Vehicle_Update",
                p => new
                    {
                        Vehicle_ID = p.Int(),
                        Vehicle_Number = p.String(maxLength: 10),
                        Vehicle_Type = p.Int(),
                        Start_Location = p.String(),
                        Destination_Location = p.String(),
                        Load_Weight = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Vehicles]
                      SET [Vehicle_Number] = @Vehicle_Number, [Vehicle_Type] = @Vehicle_Type, [Start_Location] = @Start_Location, [Destination_Location] = @Destination_Location, [Load_Weight] = @Load_Weight
                      WHERE ([Vehicle_ID] = @Vehicle_ID)"
            );
            
            CreateStoredProcedure(
                "dbo.Vehicle_Delete",
                p => new
                    {
                        Vehicle_ID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Vehicles]
                      WHERE ([Vehicle_ID] = @Vehicle_ID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Vehicle_Delete");
            DropStoredProcedure("dbo.Vehicle_Update");
            DropStoredProcedure("dbo.Vehicle_Insert");
            RenameIndex(table: "dbo.Vehicles", name: "IX_Vehicle_Type", newName: "IX_Vehicle Type");
            RenameColumn(table: "dbo.Vehicles", name: "Load_Weight", newName: "Load Weight");
            RenameColumn(table: "dbo.Vehicles", name: "Destination_Location", newName: "Destination Location");
            RenameColumn(table: "dbo.Vehicles", name: "Start_Location", newName: "Start Location");
            RenameColumn(table: "dbo.Vehicles", name: "Vehicle_Type", newName: "Vehicle Type");
            RenameColumn(table: "dbo.Vehicles", name: "Vehicle_Number", newName: "Vehicle Number");
            RenameColumn(table: "dbo.Vehicles", name: "Vehicle_ID", newName: "Vehicle ID");
        }
    }
}
