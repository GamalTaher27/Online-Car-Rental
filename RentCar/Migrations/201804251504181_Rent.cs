namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Rents",
               r => new
               {
                   Id = r.Int(nullable: false, identity: true),
                   UserId=r.Int(),
                   CarId = r.Int(),
                   From = r.DateTime(nullable: false),
                   To = r.DateTime(nullable: false),
                   TotalAmount = r.Double(),
                   State = r.String()
                  
               })
               .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Rents");
        }
    }
}
