﻿using Microsoft.EntityFrameworkCore;
using NorthwindBackend.Bussines.DTOs.ResultViews;
using NorthwindBackend.Data.Entities;
using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlphabeticalListOfProductDataModel> AlphabeticalListOfProducts { get; set; }
    public virtual DbSet<CategoryDataModel> Categories { get; set; }
    public virtual DbSet<CategorySalesFor1997DataModel> CategorySalesFor1997s { get; set; }
    public virtual DbSet<CurrentProductListDataModel> CurrentProductLists { get; set; }
    public virtual DbSet<CustomerDataModel> Customers { get; set; }
    public virtual DbSet<CustomerAndSuppliersByCityDataModel> CustomerAndSuppliersByCities { get; set; }
    public virtual DbSet<CustomerDemographicDataModel> CustomerDemographics { get; set; }
    public virtual DbSet<DisabledEmployeeDataModel> DisabledEmployees { get; set; }
    public virtual DbSet<EmployeeDataModel> Employees { get; set; }
    public virtual DbSet<InvoiceDataModel> Invoices { get; set; }
    public virtual DbSet<OrderDataModel> Orders { get; set; }
    public virtual DbSet<OrderDetailDataModel> OrderDetails { get; set; }
    public virtual DbSet<OrderDetailsExtendedDataModel> OrderDetailsExtendeds { get; set; }
    public virtual DbSet<OrderSubtotalDataModel> OrderSubtotals { get; set; }
    public virtual DbSet<OrdersQryDataModel> OrdersQries { get; set; }
    public virtual DbSet<ProductDataModel> Products { get; set; }
    public virtual DbSet<ProductSalesFor1997DataModel> ProductSalesFor1997s { get; set; }
    public virtual DbSet<ProductsAboveAveragePriceDataModel> ProductsAboveAveragePrices { get; set; }
    public virtual DbSet<ProductsByCategoryDataModel> ProductsByCategories { get; set; }
    public virtual DbSet<QuarterlyOrderDataModel> QuarterlyOrders { get; set; }
    public virtual DbSet<RegionDataModel> Regions { get; set; }
    public virtual DbSet<SalesByCategoryDataModel> SalesByCategories { get; set; }
    public virtual DbSet<SalesTotalsByAmountDataModel> SalesTotalsByAmounts { get; set; }
    public virtual DbSet<ShipperDataModel> Shippers { get; set; }
    public virtual DbSet<SummaryOfSalesByQuarterDataModel> SummaryOfSalesByQuarters { get; set; }
    public virtual DbSet<SummaryOfSalesByYearDataModel> SummaryOfSalesByYears { get; set; }
    public virtual DbSet<SupplierDataModel> Suppliers { get; set; }
    public virtual DbSet<TerritoryDataModel> Territories { get; set; }
    public virtual DbSet<UserDataModel> Users { get; set; }
    public DbSet<EmployeesSalesDTO> EmployeeSalesDTOs { get; set; } = null!;
    public DbSet<SPStatusResultDTO> SPStatusResultDTOs { get; set; } = null!;
    public DbSet<SPValidateDisabledUserResultDTO> SPValidateDisabledUserResultDTOs { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-CGCH62F\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeesSalesDTO>().HasNoKey();
        modelBuilder.Entity<SPStatusResultDTO>().HasNoKey();
        modelBuilder.Entity<SPValidateDisabledUserResultDTO>().HasNoKey();

        modelBuilder.Entity<AlphabeticalListOfProductDataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Alphabetical list of products");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<CategoryDataModel>(entity =>
        {
            entity.HasKey(e => e.CategoryId);
            entity.HasIndex(e => e.CategoryName, "CategoryName");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Picture).HasColumnType("image");
        });

        modelBuilder.Entity<CategorySalesFor1997DataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Category Sales for 1997");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.CategorySales).HasColumnType("money");
        });

        modelBuilder.Entity<CurrentProductListDataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Current Product List");
            entity.Property(e => e.ProductId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
        });

        modelBuilder.Entity<CustomerDataModel>(entity =>
        {
            entity.HasKey(e => e.CustomerId);
            entity.HasIndex(e => e.City, "City");
            entity.HasIndex(e => e.CompanyName, "CompanyName");
            entity.HasIndex(e => e.PostalCode, "PostalCode");
            entity.HasIndex(e => e.Region, "Region");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.HasMany(d => d.CustomerTypes).WithMany(p => p.Customers)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerCustomerDemo",
                    r => r.HasOne<CustomerDemographicDataModel>().WithMany()
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomerCustomerDemo"),
                    l => l.HasOne<CustomerDataModel>().WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomerCustomerDemo_Customers"),
                    j =>
                    {
                        j.HasKey("CustomerId", "CustomerTypeId").IsClustered(false);
                        j.ToTable("CustomerCustomerDemo");
                        j.IndexerProperty<string>("CustomerId")
                            .HasMaxLength(5)
                            .IsFixedLength()
                            .HasColumnName("CustomerID");
                        j.IndexerProperty<string>("CustomerTypeId")
                            .HasMaxLength(10)
                            .IsFixedLength()
                            .HasColumnName("CustomerTypeID");
                    });
        });

        modelBuilder.Entity<CustomerAndSuppliersByCityDataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Customer and Suppliers by City");
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.Relationship)
                .HasMaxLength(9)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomerDemographicDataModel>(entity =>
        {
            entity.HasKey(e => e.CustomerTypeId).IsClustered(false);
            entity.Property(e => e.CustomerTypeId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CustomerTypeID");
            entity.Property(e => e.CustomerDesc).HasColumnType("ntext");
        });

        modelBuilder.Entity<DisabledEmployeeDataModel>(entity =>
        {
            entity.HasNoKey();
            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DisabledUsers_Employees");
        });

        modelBuilder.Entity<EmployeeDataModel>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);
            entity.HasIndex(e => e.LastName, "LastName");
            entity.HasIndex(e => e.PostalCode, "PostalCode");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Extension).HasMaxLength(4);
            entity.Property(e => e.FirstName).HasMaxLength(10);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.HomePhone).HasMaxLength(24);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Notes).HasColumnType("ntext");
            entity.Property(e => e.Photo).HasColumnType("image");
            entity.Property(e => e.PhotoPath).HasMaxLength(255);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.Title).HasMaxLength(30);
            entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);
            entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo)
                .HasConstraintName("FK_Employees_Employees");
            entity.HasMany(d => d.Territories).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeTerritory",
                    r => r.HasOne<TerritoryDataModel>().WithMany()
                        .HasForeignKey("TerritoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeeTerritories_Territories"),
                    l => l.HasOne<EmployeeDataModel>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeeTerritories_Employees"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "TerritoryId").IsClustered(false);
                        j.ToTable("EmployeeTerritories");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("EmployeeID");
                        j.IndexerProperty<string>("TerritoryId")
                            .HasMaxLength(20)
                            .HasColumnName("TerritoryID");
                    });
        });

        modelBuilder.Entity<InvoiceDataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Invoices");
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName).HasMaxLength(40);
            entity.Property(e => e.ExtendedPrice).HasColumnType("money");
            entity.Property(e => e.Freight).HasColumnType("money");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.Salesperson).HasMaxLength(31);
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.Property(e => e.ShipperName).HasMaxLength(40);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<OrderDataModel>(entity =>
        {
            entity.HasKey(e => e.OrderId);
            entity.HasIndex(e => e.CustomerId, "CustomerID");
            entity.HasIndex(e => e.CustomerId, "CustomersOrders");
            entity.HasIndex(e => e.EmployeeId, "EmployeeID");
            entity.HasIndex(e => e.EmployeeId, "EmployeesOrders");
            entity.HasIndex(e => e.OrderDate, "OrderDate");
            entity.HasIndex(e => e.ShipPostalCode, "ShipPostalCode");
            entity.HasIndex(e => e.ShippedDate, "ShippedDate");
            entity.HasIndex(e => e.ShipVia, "ShippersOrders");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Freight)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Orders_Customers");
            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Orders_Employees");
            entity.HasOne(d => d.ShipViaNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipVia)
                .HasConstraintName("FK_Orders_Shippers");
        });

        modelBuilder.Entity<OrderDetailDataModel>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK_Order_Details");
            entity.ToTable("Order Details");
            entity.HasIndex(e => e.OrderId, "OrderID");
            entity.HasIndex(e => e.OrderId, "OrdersOrder_Details");
            entity.HasIndex(e => e.ProductId, "ProductID");
            entity.HasIndex(e => e.ProductId, "ProductsOrder_Details");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Quantity).HasDefaultValue((short)1);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Orders");
            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Products");
        });

        modelBuilder.Entity<OrderDetailsExtendedDataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Order Details Extended");
            entity.Property(e => e.ExtendedPrice).HasColumnType("money");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<OrderSubtotalDataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Order Subtotals");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Subtotal).HasColumnType("money");
        });

        modelBuilder.Entity<OrdersQryDataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Orders Qry");
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Freight).HasColumnType("money");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProductDataModel>(entity =>
        {
            entity.HasKey(e => e.ProductId);
            entity.HasIndex(e => e.CategoryId, "CategoriesProducts");
            entity.HasIndex(e => e.CategoryId, "CategoryID");
            entity.HasIndex(e => e.ProductName, "ProductName");
            entity.HasIndex(e => e.SupplierId, "SupplierID");
            entity.HasIndex(e => e.SupplierId, "SuppliersProducts");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.ReorderLevel).HasDefaultValue((short)0);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.UnitsInStock).HasDefaultValue((short)0);
            entity.Property(e => e.UnitsOnOrder).HasDefaultValue((short)0);
            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Categories");
            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Products_Suppliers");
        });

        modelBuilder.Entity<ProductSalesFor1997DataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Product Sales for 1997");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.ProductSales).HasColumnType("money");
        });

        modelBuilder.Entity<ProductsAboveAveragePriceDataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Products Above Average Price");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<ProductsByCategoryDataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Products by Category");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
        });

        modelBuilder.Entity<QuarterlyOrderDataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Quarterly Orders");
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
        });

        modelBuilder.Entity<RegionDataModel>(entity =>
        {
            entity.HasKey(e => e.RegionId).IsClustered(false);
            entity.ToTable("Region");
            entity.Property(e => e.RegionId)
                .ValueGeneratedNever()
                .HasColumnName("RegionID");
            entity.Property(e => e.RegionDescription)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<SalesByCategoryDataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Sales by Category");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.ProductSales).HasColumnType("money");
        });

        modelBuilder.Entity<SalesTotalsByAmountDataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Sales Totals by Amount");
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.SaleAmount).HasColumnType("money");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ShipperDataModel>(entity =>
        {
            entity.HasKey(e => e.ShipperId);
            entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Phone).HasMaxLength(24);
        });

        modelBuilder.Entity<SummaryOfSalesByQuarterDataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Summary of Sales by Quarter");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.Property(e => e.Subtotal).HasColumnType("money");
        });

        modelBuilder.Entity<SummaryOfSalesByYearDataModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Summary of Sales by Year");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.Property(e => e.Subtotal).HasColumnType("money");
        });

        modelBuilder.Entity<SupplierDataModel>(entity =>
        {
            entity.HasKey(e => e.SupplierId);
            entity.HasIndex(e => e.CompanyName, "CompanyName");
            entity.HasIndex(e => e.PostalCode, "PostalCode");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.HomePage).HasColumnType("ntext");
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
        });

        modelBuilder.Entity<TerritoryDataModel>(entity =>
        {
            entity.HasKey(e => e.TerritoryId).IsClustered(false);
            entity.Property(e => e.TerritoryId)
                .HasMaxLength(20)
                .HasColumnName("TerritoryID");
            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.TerritoryDescription)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.HasOne(d => d.Region).WithMany(p => p.Territories)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Territories_Region");
        });

        modelBuilder.Entity<UserDataModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F0965EB0F");
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Role).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}