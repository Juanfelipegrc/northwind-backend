using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class ProductsAboveAveragePriceDataModel
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
