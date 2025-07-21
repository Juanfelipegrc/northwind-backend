using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class TerritoryDataModel
{
    public string TerritoryId { get; set; } = null!;

    public string TerritoryDescription { get; set; } = null!;

    public int RegionId { get; set; }

    public virtual RegionDataModel Region { get; set; } = null!;

    public virtual ICollection<EmployeeDataModel> Employees { get; set; } = new List<EmployeeDataModel>();
}
