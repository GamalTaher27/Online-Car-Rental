namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColToUser6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisterViewModels", "Balance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegisterViewModels", "Balance");
        }
    }
}
