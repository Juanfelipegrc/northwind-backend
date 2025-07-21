using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class CustomerAndSuppliersByCityDataModel
{
    public string? City { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string Relationship { get; set; } = null!;
}
