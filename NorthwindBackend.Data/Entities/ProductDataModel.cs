using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class ProductDataModel
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    public string? QuantityPerUnit { get; set; }

    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    public virtual CategoryDataModel? Category { get; set; }

    public virtual ICollection<OrderDetailDataModel> OrderDetails { get; set; } = new List<OrderDetailDataModel>();

    public virtual SupplierDataModel? Supplier { get; set; }
}
