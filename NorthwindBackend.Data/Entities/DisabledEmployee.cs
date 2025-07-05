using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class DisabledEmployee
{
    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
