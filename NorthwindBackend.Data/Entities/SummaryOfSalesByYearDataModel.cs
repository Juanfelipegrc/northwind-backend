﻿using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class SummaryOfSalesByYearDataModel
{
    public DateTime? ShippedDate { get; set; }

    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
