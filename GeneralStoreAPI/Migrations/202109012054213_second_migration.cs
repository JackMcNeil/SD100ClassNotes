namespace GeneralStoreAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second_migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "DateOfTransaction", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "DateOfTransaction");
            DropColumn("dbo.Customers", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "DateOfTransaction", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transactions", "Quantity");
            DropColumn("dbo.Transactions", "DateOfTransaction");
        }
    }
}
