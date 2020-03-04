namespace Online_Logistics_Registration_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "MobileNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 7));
            CreateIndex("dbo.Users", "MobileNumber", unique: true);
            CreateIndex("dbo.Users", "Email", unique: true);
            CreateIndex("dbo.Users", "UserName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "MobileNumber" });
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "MobileNumber", c => c.String(nullable: false));
        }
    }
}
