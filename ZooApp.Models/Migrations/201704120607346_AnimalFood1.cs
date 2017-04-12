namespace ZooApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalFood1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "Quantiry", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "Quantiry");
        }
    }
}
