using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class OrderSubtotalDataModel
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
