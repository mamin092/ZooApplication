namespace ZooApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalFoodUniqeNameAdded : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Animals", "Ix_AnimalName");
            DropIndex("dbo.Foods", "Ix_AnimalName");
            AlterColumn("dbo.Animals", "Origin", c => c.String(maxLength: 50));
            CreateIndex("dbo.Animals", "Name", unique: true, name: "Ix_AnimalName");
            CreateIndex("dbo.Animals", "Origin", name: "Ix_AnimalOrigin");
            CreateIndex("dbo.Foods", "Name", unique: true, name: "Ix_FoodName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Foods", "Ix_FoodName");
            DropIndex("dbo.Animals", "Ix_AnimalOrigin");
            DropIndex("dbo.Animals", "Ix_AnimalName");
            AlterColumn("dbo.Animals", "Origin", c => c.String());
            CreateIndex("dbo.Foods", "Name", name: "Ix_AnimalName");
            CreateIndex("dbo.Animals", "Name", name: "Ix_AnimalName");
        }
    }
}
