namespace ZooApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addfoodprice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foods", "Price");
        }
    }
}
