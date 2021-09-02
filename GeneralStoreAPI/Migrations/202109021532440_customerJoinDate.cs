namespace GeneralStoreAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerJoinDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DateJoined", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DateJoined");
        }
    }
}
