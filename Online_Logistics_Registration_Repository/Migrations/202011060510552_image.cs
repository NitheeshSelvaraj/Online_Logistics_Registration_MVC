namespace Online_Logistics_Registration_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Image", c => c.Binary());
            AlterStoredProcedure(
                "dbo.Vehicle_Insert",
                p => new
                    {
                        Vehicle_Number = p.String(maxLength: 10),
                        Vehicle_Type = p.Int(),
                        Start_Location = p.String(),
                        Destination_Location = p.String(),
                        Distance = p.Int(),
                        Rate = p.Int(),
                        Load_Weight = p.Int(),
                        Image = p.Binary(),
                        Status = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Vehicles]([Vehicle_Number], [Vehicle_Type], [Start_Location], [Destination_Location], [Distance], [Rate], [Load_Weight], [Image], [Status])
                      VALUES (@Vehicle_Number, @Vehicle_Type, @Start_Location, @Destination_Location, @Distance, @Rate, @Load_Weight, @Image, @Status)
                      
                      DECLARE @Vehicle_ID int
                      SELECT @Vehicle_ID = [Vehicle_ID]
                      FROM [dbo].[Vehicles]
                      WHERE @@ROWCOUNT > 0 AND [Vehicle_ID] = scope_identity()
                      
                      SELECT t0.[Vehicle_ID]
                      FROM [dbo].[Vehicles] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Vehicle_ID] = @Vehicle_ID"
            );
            
            AlterStoredProcedure(
                "dbo.Vehicle_Update",
                p => new
                    {
                        Vehicle_ID = p.Int(),
                        Vehicle_Number = p.String(maxLength: 10),
                        Vehicle_Type = p.Int(),
                        Start_Location = p.String(),
                        Destination_Location = p.String(),
                        Distance = p.Int(),
                        Rate = p.Int(),
                        Load_Weight = p.Int(),
                        Image = p.Binary(),
                        Status = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Vehicles]
                      SET [Vehicle_Number] = @Vehicle_Number, [Vehicle_Type] = @Vehicle_Type, [Start_Location] = @Start_Location, [Destination_Location] = @Destination_Location, [Distance] = @Distance, [Rate] = @Rate, [Load_Weight] = @Load_Weight, [Image] = @Image, [Status] = @Status
                      WHERE ([Vehicle_ID] = @Vehicle_ID)"
            );
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Image");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
