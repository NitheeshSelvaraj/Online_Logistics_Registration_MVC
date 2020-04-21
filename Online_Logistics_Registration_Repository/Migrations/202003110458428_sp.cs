namespace Online_Logistics_Registration_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sp : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.VehicleTypes", name: "Vehicle Type ID", newName: "Vehicle_Type_ID");
            RenameColumn(table: "dbo.VehicleTypes", name: "Vehicle Type", newName: "Vehicle_Type");
            CreateStoredProcedure(
                "dbo.VehicleType_Insert",
                p => new
                    {
                        Vehicle_Type = p.String(maxLength: 25),
                    },
                body:
                    @"INSERT [dbo].[VehicleTypes]([Vehicle_Type])
                      VALUES (@Vehicle_Type)
                      
                      DECLARE @Vehicle_Type_ID int
                      SELECT @Vehicle_Type_ID = [Vehicle_Type_ID]
                      FROM [dbo].[VehicleTypes]
                      WHERE @@ROWCOUNT > 0 AND [Vehicle_Type_ID] = scope_identity()
                      
                      SELECT t0.[Vehicle_Type_ID]
                      FROM [dbo].[VehicleTypes] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Vehicle_Type_ID] = @Vehicle_Type_ID"
            );
            
            CreateStoredProcedure(
                "dbo.VehicleType_Update",
                p => new
                    {
                        Vehicle_Type_ID = p.Int(),
                        Vehicle_Type = p.String(maxLength: 25),
                    },
                body:
                    @"UPDATE [dbo].[VehicleTypes]
                      SET [Vehicle_Type] = @Vehicle_Type
                      WHERE ([Vehicle_Type_ID] = @Vehicle_Type_ID)"
            );
            
            CreateStoredProcedure(
                "dbo.VehicleType_Delete",
                p => new
                    {
                        Vehicle_Type_ID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[VehicleTypes]
                      WHERE ([Vehicle_Type_ID] = @Vehicle_Type_ID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.VehicleType_Delete");
            DropStoredProcedure("dbo.VehicleType_Update");
            DropStoredProcedure("dbo.VehicleType_Insert");
            RenameColumn(table: "dbo.VehicleTypes", name: "Vehicle_Type", newName: "Vehicle Type");
            RenameColumn(table: "dbo.VehicleTypes", name: "Vehicle_Type_ID", newName: "Vehicle Type ID");
        }
    }
}
