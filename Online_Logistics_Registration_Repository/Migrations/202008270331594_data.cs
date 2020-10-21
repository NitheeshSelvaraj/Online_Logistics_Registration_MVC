namespace Online_Logistics_Registration_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Points", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Points");
        }
    }
}
