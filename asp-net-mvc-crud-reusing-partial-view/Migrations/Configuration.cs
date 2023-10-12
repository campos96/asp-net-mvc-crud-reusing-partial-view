namespace asp_net_mvc_crud_reusing_partial_view.Migrations
{
    using asp_net_mvc_crud_reusing_partial_view.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<asp_net_mvc_crud_reusing_partial_view.Models.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(asp_net_mvc_crud_reusing_partial_view.Models.StoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var suppliers = new List<Supplier>
            {
                new Supplier{ Name = "Apple", City = "Cupertino", Country = "United States", Phone = "123456789"},
                new Supplier{ Name = "Samsung", City = "Suwon-si", Country = "South Korea", Phone = "123456789"},
                new Supplier{ Name = "Huawei", City = "Shenzhen", Country = "China", Phone = "123456789"},
            };

            suppliers.ForEach(s => context.Suppliers.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var products = new List<Product> {
                new Product{ Name = "Iphone 13", SupplierID = context.Suppliers.Single(s => s.Name == "Apple").ID, Price = 799.999m, IsDiscontinued = false },
                new Product{ Name = "Iphone 13 Pro", SupplierID = context.Suppliers.Single(s => s.Name == "Apple").ID, Price = 999.99m, IsDiscontinued = false },
                new Product{ Name = "Iphone 13 Pro Max", SupplierID = context.Suppliers.Single(s => s.Name == "Apple").ID, Price = 1099.99m, IsDiscontinued = false },
                new Product{ Name = "Galaxy S21 5G", SupplierID = context.Suppliers.Single(s => s.Name == "Samsung").ID, Price = 799.99m, IsDiscontinued = false },
                new Product{ Name = "Galaxy Z Flip3 5G", SupplierID = context.Suppliers.Single(s => s.Name == "Samsung").ID, Price = 999.99m, IsDiscontinued = false },
                new Product{ Name = "Galaxy Z Fold3 5G", SupplierID = context.Suppliers.Single(s => s.Name == "Samsung").ID, Price = 1799.99m, IsDiscontinued = false },
                new Product{ Name = "P30 Pro", SupplierID = context.Suppliers.Single(s => s.Name == "Huawei").ID, Price = 740, IsDiscontinued = false },
                new Product{ Name = "Nova 5T", SupplierID = context.Suppliers.Single(s => s.Name == "Huawei").ID, Price = 320, IsDiscontinued = false },
                new Product{ Name = "P40 lite 4G", SupplierID = context.Suppliers.Single(s => s.Name == "Huawei").ID, Price = 280, IsDiscontinued = false },
            };

            products.ForEach(s => context.Products.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var customers = new List<Customer> {
                new Customer { FirstName = "John", LastName = "Doe", City = "San Francisco", Country = "United States", Phone = "123456789" },
                new Customer { FirstName = "Jane", LastName = "Doe", City = "Portland", Country = "United States", Phone = "123456789" },
            };

            customers.ForEach(s => context.Customers.AddOrUpdate(p => p.FirstName, s));
            context.SaveChanges();

            var order = new Order {
                CustomerID = customers.First().ID,
                Date = DateTime.Now,
                OrderLines = products.Select(p => new OrderLine { ProductID = p.ID, Quantity = 1 }).ToList()
            };

            context.Orders.AddOrUpdate(o => o.ID, order);
            context.SaveChanges();
        }
    }
}
