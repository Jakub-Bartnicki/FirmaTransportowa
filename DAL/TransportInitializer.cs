using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FirmaTransportowa.Models;

namespace FirmaTransportowa.DAL
{
    public class TransportInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<TransportContext>
    {
        protected override void Seed(TransportContext context)
        {
            var products = new List<Product>
            {
                new Product{Name="Zasoby",Description="Duzo zasobow",BuyPrice=9.99,Weight=100},
                new Product{Name="Paczka",Description="Mala paczka",BuyPrice=4.99,Weight=15.5}
            };
            products.ForEach(x => context.Products.Add(x));
            context.SaveChanges();

            var warehouses = new List<Warehouse>
            {
                new Warehouse{AddressID=1}
            };
            warehouses.ForEach(x => context.Warehouses.Add(x));
            context.SaveChanges();

            var warehouseProducts = new List<WarehouseProduct>
            {
                new WarehouseProduct{WarehouseID=1,ProductID=1,QuantityInStock=15,MaxQuantity=20},
                new WarehouseProduct{WarehouseID=1,ProductID=2,QuantityInStock=10,MaxQuantity=10}
            };
            warehouseProducts.ForEach(x => context.WarehouseProducts.Add(x));
            context.SaveChanges();
        }
    }
}