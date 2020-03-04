namespace Online_Logistics_Registration_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Database1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Role", c => c.String(nullable: false,defaultValue:"User"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Role");
        }
    }
}
