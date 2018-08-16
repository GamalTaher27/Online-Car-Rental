namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCar1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cars", "category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "category", c => c.String());
        }
    }
}
