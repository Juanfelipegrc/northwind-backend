﻿using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class ProductSalesFor1997DataModel
{
    public string CategoryName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal? ProductSales { get; set; }
}
