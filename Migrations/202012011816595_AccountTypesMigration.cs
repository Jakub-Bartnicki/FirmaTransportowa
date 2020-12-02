namespace FirmaTransportowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountTypesMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "Type", c => c.String(nullable: false, maxLength: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Account", "Type");
        }
    }
}
