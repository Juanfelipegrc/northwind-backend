﻿using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class ProductsByCategoryDataModel
{
    public string CategoryName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? QuantityPerUnit { get; set; }

    public short? UnitsInStock { get; set; }

    public bool Discontinued { get; set; }
}
