using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class OrderDetailDataModel
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal UnitPrice { get; set; }

    public short Quantity { get; set; }

    public float Discount { get; set; }

    public virtual OrderDataModel Order { get; set; } = null!;

    public virtual ProductDataModel Product { get; set; } = null!;
}
