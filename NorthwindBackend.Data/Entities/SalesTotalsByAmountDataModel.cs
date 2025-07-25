﻿using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class SalesTotalsByAmountDataModel
{
    public decimal? SaleAmount { get; set; }

    public int OrderId { get; set; }

    public string CompanyName { get; set; } = null!;

    public DateTime? ShippedDate { get; set; }
}
