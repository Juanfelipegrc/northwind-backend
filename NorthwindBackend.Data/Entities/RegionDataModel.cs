using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class RegionDataModel
{
    public int RegionId { get; set; }

    public string RegionDescription { get; set; } = null!;

    public virtual ICollection<TerritoryDataModel> Territories { get; set; } = new List<TerritoryDataModel>();
}
