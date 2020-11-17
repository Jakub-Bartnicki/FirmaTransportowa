namespace FirmaTransportowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        BuyPrice = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.WarehouseProduct",
                c => new
                    {
                        WarehouseProductID = c.Int(nullable: false, identity: true),
                        WarehouseID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        QuantityInStock = c.Int(nullable: false),
                        MaxQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WarehouseProductID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseID, cascadeDelete: true)
                .Index(t => t.WarehouseID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Warehouse",
                c => new
                    {
                        WarehouseID = c.Int(nullable: false, identity: true),
                        AddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WarehouseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WarehouseProduct", "WarehouseID", "dbo.Warehouse");
            DropForeignKey("dbo.WarehouseProduct", "ProductID", "dbo.Product");
            DropIndex("dbo.WarehouseProduct", new[] { "ProductID" });
            DropIndex("dbo.WarehouseProduct", new[] { "WarehouseID" });
            DropTable("dbo.Warehouse");
            DropTable("dbo.WarehouseProduct");
            DropTable("dbo.Product");
        }
    }
}
