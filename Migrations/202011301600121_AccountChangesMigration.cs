namespace FirmaTransportowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountChangesMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Account", "Login", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Account", "PasswordHash", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Account", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Account", "Email", c => c.String(maxLength: 255));
            AlterColumn("dbo.Account", "PasswordHash", c => c.String(maxLength: 255));
            AlterColumn("dbo.Account", "Login", c => c.String(maxLength: 50));
        }
    }
}
