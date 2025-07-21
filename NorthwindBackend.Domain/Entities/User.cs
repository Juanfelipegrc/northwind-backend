using System;
using System.Collections.Generic;

namespace NorthwindBackend.Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string Role { get; set; }


    public User(
        int id,
        string lastName,
        string firstName,
        string role
    )
    {
        if(id == 0)
        {
            throw new ArgumentException("Id is not valid", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name can be empty", nameof(lastName));
        }

        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name can be empty", nameof(firstName));
        }

        if (string.IsNullOrWhiteSpace(role))
        {
            throw new ArgumentException("Role can be empty", nameof(role));
        }


        Id = id;
        LastName = lastName;
        FirstName = firstName;
        Role = role;
    }

}
