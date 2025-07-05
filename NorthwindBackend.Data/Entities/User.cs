using System;
using System.Collections.Generic;

namespace NorthwindBackend.Data.Entities;

public partial class User
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Role { get; set; } = null!;
}
