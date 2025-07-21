using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class ShipperDataModel
{
    public int ShipperId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<OrderDataModel> Orders { get; set; } = new List<OrderDataModel>();
}
