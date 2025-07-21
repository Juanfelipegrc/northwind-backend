using System;
using System.Collections.Generic;

namespace NorthwindBackend.Domain.Entities;

public partial class Employee
{
    public int Id { get; private set; }

    public string LastName { get; private set; } = null!;

    public string FirstName { get; private set; } = null!;

    public string? Title { get; private set; }

    public string? TitleOfCourtesy { get; private set; }

    public DateTime? BirthDate { get; private set; }

    public string Address { get; private set; }

    public string City { get; private set; }

    public string Region { get; private set; }

    public string Country { get; private set; }

    public string HomePhone { get; private set; }

    
    public Employee(
        int id,
        string lastName,
        string firstName,
        string? title,
        string? titleOfCourtesy,
        DateTime? birthDate,
        string address,
        string city,
        string region,
        string country,
        string homePhone
    )
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name can not be empty", nameof(lastName));
        }

        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name can not be empty", nameof(firstName));
        }

        if(birthDate != null)
        {
            var age = CalculateAge(birthDate);

            if (age < 14)
            {
                throw new ArgumentException("Employee is not of working age", nameof(age));
            }

            if (age > 120)
            {
                throw new ArgumentException("Employee age is not valid", nameof(age));
            }
        }

        if (string.IsNullOrWhiteSpace(address))
        {
            throw new ArgumentException("Address can not be empty", nameof(address));
        }

        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException("City can not be empty", nameof(city));
        }

        if (string.IsNullOrWhiteSpace(region))
        {
            throw new ArgumentException("region can not be empty", nameof(region));
        }

        if (string.IsNullOrWhiteSpace(country))
        {
            throw new ArgumentException("Country can not be empty", nameof(country));
        }

        if (string.IsNullOrWhiteSpace(homePhone))
        {
            throw new ArgumentException("Phone can not be empty", nameof(homePhone));
        }

        if (homePhone.Length > 20)
        {
            throw new ArgumentException("Phone can not have more than 20 characters", nameof(homePhone));
        }

        Id = id;
        LastName = lastName;
        FirstName = firstName;
        Title = title;
        TitleOfCourtesy = titleOfCourtesy;
        BirthDate = birthDate;
        Address = address;
        City = city;
        Region = region;
        Country = country;
        HomePhone = homePhone;

    }

    private static int? CalculateAge(DateTime? birthDate)
    {
        if (birthDate == null)
            return null;

        var today = DateTime.Today;
        int age = today.Year - birthDate.Value.Year;
        if (birthDate > today.AddYears(-age)) age--;

        return age;

    }

}
