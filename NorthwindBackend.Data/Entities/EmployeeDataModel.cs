﻿using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class EmployeeDataModel
{
    public int EmployeeId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Title { get; set; }

    public string? TitleOfCourtesy { get; set; }

    public DateTime? BirthDate { get; set; }

    public DateTime? HireDate { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? HomePhone { get; set; }

    public string? Extension { get; set; }

    public byte[]? Photo { get; set; }

    public string? Notes { get; set; }

    public int? ReportsTo { get; set; }

    public string? PhotoPath { get; set; }

    public virtual ICollection<EmployeeDataModel> InverseReportsToNavigation { get; set; } = new List<EmployeeDataModel>();

    public virtual ICollection<OrderDataModel> Orders { get; set; } = new List<OrderDataModel>();

    public virtual EmployeeDataModel? ReportsToNavigation { get; set; }

    public virtual ICollection<TerritoryDataModel> Territories { get; set; } = new List<TerritoryDataModel>();
}
