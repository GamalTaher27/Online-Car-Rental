namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColToCar : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RegisterViewModels", "Balance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegisterViewModels", "Balance", c => c.Double(nullable: false));
        }
    }
}
