namespace FirmaTransportowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Login = c.String(maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        PasswordHash = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.AccountID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false),
                        PersonDetailsID = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Account", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.PersonDetails", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        RequiredDate = c.DateTime(nullable: false),
                        ShippedDate = c.DateTime(nullable: false),
                        Status = c.String(maxLength: 20),
                        Comments = c.String(maxLength: 255),
                        Price = c.Decimal(nullable: false, precision: 10, scale: 2),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customer", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.OrderProduct",
                c => new
                    {
                        OrderProductID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderProductID)
                .ForeignKey("dbo.Order", t => t.OrderID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                        Description = c.String(maxLength: 255),
                        BuyPrice = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Weight = c.Decimal(nullable: false, precision: 10, scale: 3),
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
                .ForeignKey("dbo.Product", t => t.ProductID)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseID)
                .Index(t => t.WarehouseID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Warehouse",
                c => new
                    {
                        WarehouseID = c.Int(nullable: false),
                        AddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WarehouseID)
                .ForeignKey("dbo.Address", t => t.WarehouseID, cascadeDelete: true)
                .Index(t => t.WarehouseID);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        Country = c.String(maxLength: 40),
                        PostalCode = c.String(maxLength: 40),
                        City = c.String(maxLength: 100),
                        Street = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.AddressID);
            
            CreateTable(
                "dbo.PersonDetails",
                c => new
                    {
                        PersonDetailsID = c.Int(nullable: false),
                        AddressID = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 60),
                        LastName = c.String(maxLength: 60),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonDetailsID)
                .ForeignKey("dbo.Address", t => t.PersonDetailsID, cascadeDelete: true)
                .Index(t => t.PersonDetailsID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false),
                        ManagerID = c.Int(nullable: false),
                        PersonDetailsID = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                        JobTitle = c.String(maxLength: 100),
                        Salary = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Transport_TransportID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Account", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Manager", t => t.ManagerID)
                .ForeignKey("dbo.PersonDetails", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Transport", t => t.Transport_TransportID)
                .Index(t => t.EmployeeID)
                .Index(t => t.ManagerID)
                .Index(t => t.Transport_TransportID);
            
            CreateTable(
                "dbo.Manager",
                c => new
                    {
                        ManagerID = c.Int(nullable: false),
                        PersonDetailsID = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ManagerID)
                .ForeignKey("dbo.Account", t => t.ManagerID, cascadeDelete: true)
                .ForeignKey("dbo.PersonDetails", t => t.ManagerID, cascadeDelete: true)
                .Index(t => t.ManagerID);
            
            CreateTable(
                "dbo.Transport",
                c => new
                    {
                        TransportID = c.Int(nullable: false),
                        RouteID = c.Int(nullable: false),
                        TruckID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        DepartureDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransportID)
                .ForeignKey("dbo.Order", t => t.TransportID)
                .ForeignKey("dbo.Route", t => t.TransportID)
                .Index(t => t.TransportID);
            
            CreateTable(
                "dbo.Route",
                c => new
                    {
                        RouteID = c.Int(nullable: false),
                        TruckID = c.Int(nullable: false),
                        WarehouseID = c.Int(nullable: false),
                        AddressID = c.Int(nullable: false),
                        Distance = c.Decimal(nullable: false, precision: 9, scale: 3),
                    })
                .PrimaryKey(t => t.RouteID)
                .ForeignKey("dbo.Address", t => t.RouteID, cascadeDelete: true)
                .ForeignKey("dbo.Warehouse", t => t.RouteID)
                .Index(t => t.RouteID);
            
            CreateTable(
                "dbo.Truck",
                c => new
                    {
                        TruckID = c.Int(nullable: false, identity: true),
                        SemitrailerID = c.Int(nullable: false),
                        RegistrationNr = c.String(maxLength: 10),
                        Brand = c.String(maxLength: 40),
                        Model = c.String(maxLength: 40),
                        ProductionYear = c.DateTime(nullable: false),
                        Mileage = c.Int(nullable: false),
                        VIN = c.String(maxLength: 17),
                        Route_RouteID = c.Int(),
                        Transport_TransportID = c.Int(),
                    })
                .PrimaryKey(t => t.TruckID)
                .ForeignKey("dbo.Route", t => t.Route_RouteID)
                .ForeignKey("dbo.Transport", t => t.Transport_TransportID)
                .Index(t => t.Route_RouteID)
                .Index(t => t.Transport_TransportID);
            
            CreateTable(
                "dbo.Semitrailer",
                c => new
                    {
                        SemitrailerID = c.Int(nullable: false, identity: true),
                        RegistrationNr = c.String(maxLength: 10),
                        Capacity = c.Decimal(nullable: false, precision: 10, scale: 3),
                        Truck_TruckID = c.Int(),
                    })
                .PrimaryKey(t => t.SemitrailerID)
                .ForeignKey("dbo.Truck", t => t.Truck_TruckID)
                .Index(t => t.Truck_TruckID);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        PaymentID = c.String(nullable: false, maxLength: 255),
                        OrderID = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Order_OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Order", t => t.Order_OrderID, cascadeDelete: true)
                .Index(t => t.Order_OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "CustomerID", "dbo.PersonDetails");
            DropForeignKey("dbo.Payment", "Order_OrderID", "dbo.Order");
            DropForeignKey("dbo.OrderProduct", "ProductID", "dbo.Product");
            DropForeignKey("dbo.WarehouseProduct", "WarehouseID", "dbo.Warehouse");
            DropForeignKey("dbo.Warehouse", "WarehouseID", "dbo.Address");
            DropForeignKey("dbo.Transport", "TransportID", "dbo.Route");
            DropForeignKey("dbo.Route", "RouteID", "dbo.Warehouse");
            DropForeignKey("dbo.Truck", "Transport_TransportID", "dbo.Transport");
            DropForeignKey("dbo.Semitrailer", "Truck_TruckID", "dbo.Truck");
            DropForeignKey("dbo.Truck", "Route_RouteID", "dbo.Route");
            DropForeignKey("dbo.Route", "RouteID", "dbo.Address");
            DropForeignKey("dbo.Transport", "TransportID", "dbo.Order");
            DropForeignKey("dbo.Employee", "Transport_TransportID", "dbo.Transport");
            DropForeignKey("dbo.Employee", "EmployeeID", "dbo.PersonDetails");
            DropForeignKey("dbo.Employee", "ManagerID", "dbo.Manager");
            DropForeignKey("dbo.Manager", "ManagerID", "dbo.PersonDetails");
            DropForeignKey("dbo.Manager", "ManagerID", "dbo.Account");
            DropForeignKey("dbo.Employee", "EmployeeID", "dbo.Account");
            DropForeignKey("dbo.PersonDetails", "PersonDetailsID", "dbo.Address");
            DropForeignKey("dbo.WarehouseProduct", "ProductID", "dbo.Product");
            DropForeignKey("dbo.OrderProduct", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Order", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Customer", "CustomerID", "dbo.Account");
            DropIndex("dbo.Payment", new[] { "Order_OrderID" });
            DropIndex("dbo.Semitrailer", new[] { "Truck_TruckID" });
            DropIndex("dbo.Truck", new[] { "Transport_TransportID" });
            DropIndex("dbo.Truck", new[] { "Route_RouteID" });
            DropIndex("dbo.Route", new[] { "RouteID" });
            DropIndex("dbo.Transport", new[] { "TransportID" });
            DropIndex("dbo.Manager", new[] { "ManagerID" });
            DropIndex("dbo.Employee", new[] { "Transport_TransportID" });
            DropIndex("dbo.Employee", new[] { "ManagerID" });
            DropIndex("dbo.Employee", new[] { "EmployeeID" });
            DropIndex("dbo.PersonDetails", new[] { "PersonDetailsID" });
            DropIndex("dbo.Warehouse", new[] { "WarehouseID" });
            DropIndex("dbo.WarehouseProduct", new[] { "ProductID" });
            DropIndex("dbo.WarehouseProduct", new[] { "WarehouseID" });
            DropIndex("dbo.OrderProduct", new[] { "ProductID" });
            DropIndex("dbo.OrderProduct", new[] { "OrderID" });
            DropIndex("dbo.Order", new[] { "CustomerID" });
            DropIndex("dbo.Customer", new[] { "CustomerID" });
            DropTable("dbo.Payment");
            DropTable("dbo.Semitrailer");
            DropTable("dbo.Truck");
            DropTable("dbo.Route");
            DropTable("dbo.Transport");
            DropTable("dbo.Manager");
            DropTable("dbo.Employee");
            DropTable("dbo.PersonDetails");
            DropTable("dbo.Address");
            DropTable("dbo.Warehouse");
            DropTable("dbo.WarehouseProduct");
            DropTable("dbo.Product");
            DropTable("dbo.OrderProduct");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
            DropTable("dbo.Account");
        }
    }
}
