namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCar2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "category");
        }
    }
}
