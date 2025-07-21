using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class OrderDataModel
{
    public int OrderId { get; set; }

    public string? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public int? ShipVia { get; set; }

    public decimal? Freight { get; set; }

    public string? ShipName { get; set; }

    public string? ShipAddress { get; set; }

    public string? ShipCity { get; set; }

    public string? ShipRegion { get; set; }

    public string? ShipPostalCode { get; set; }

    public string? ShipCountry { get; set; }

    public virtual CustomerDataModel? Customer { get; set; }

    public virtual EmployeeDataModel? Employee { get; set; }

    public virtual ICollection<OrderDetailDataModel> OrderDetails { get; set; } = new List<OrderDetailDataModel>();

    public virtual ShipperDataModel? ShipViaNavigation { get; set; }
}
