using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class DisabledEmployeeDataModel
{
    public int EmployeeId { get; set; }

    public virtual EmployeeDataModel Employee { get; set; } = null!;
}
