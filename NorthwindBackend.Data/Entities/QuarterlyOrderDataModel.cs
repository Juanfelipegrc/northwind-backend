using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class QuarterlyOrderDataModel
{
    public string? CustomerId { get; set; }

    public string? CompanyName { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }
}
