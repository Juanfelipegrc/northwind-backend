using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class CategoryDataModel
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public virtual ICollection<ProductDataModel> Products { get; set; } = new List<ProductDataModel>();
}
