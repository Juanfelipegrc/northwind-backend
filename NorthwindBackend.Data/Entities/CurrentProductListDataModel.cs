using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class CurrentProductListDataModel
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
