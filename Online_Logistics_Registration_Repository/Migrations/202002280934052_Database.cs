namespace Online_Logistics_Registration_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Database : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "Id", newName: "UserId");
            AddColumn("dbo.Users", "MobileNumber", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Users", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "MobileNumber");
            RenameColumn(table: "dbo.Users", name: "UserId", newName: "Id");
        }
    }
}
