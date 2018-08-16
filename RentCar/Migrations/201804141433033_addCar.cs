namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        category = c.String(),
                        Model = c.String(nullable: false),
                        Color = c.String(),
                        Image = c.String(),
                        NumberOfChairs = c.Int(nullable: false),
                        State = c.String(),
                        Amount = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cars");
        }
    }
}
