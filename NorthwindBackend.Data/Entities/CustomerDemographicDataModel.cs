using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class CustomerDemographicDataModel
{
    public string CustomerTypeId { get; set; } = null!;

    public string? CustomerDesc { get; set; }

    public virtual ICollection<CustomerDataModel> Customers { get; set; } = new List<CustomerDataModel>();
}
