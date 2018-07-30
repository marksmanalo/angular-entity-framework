namespace PG1Products.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustomerPhoneNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "PhoneNumber");
        }
    }
}
