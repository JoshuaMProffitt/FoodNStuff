namespace FoodNStuff.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transactions", "CreditCard");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "CreditCard", c => c.Int(nullable: false));
        }
    }
}
