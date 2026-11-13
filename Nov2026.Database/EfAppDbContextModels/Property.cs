using System;
using System.Collections.Generic;

namespace Nov2026.Database.EfAppDbContextModels;

public partial class Property
{
    public int PropertyId { get; set; }

    public int OwnerId { get; set; }

    public string Title { get; set; } = null!;

    public string PropertyType { get; set; } = null!;

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string? StateProvince { get; set; }

    public string? PostalCode { get; set; }

    public string Country { get; set; } = null!;

    public int Bedrooms { get; set; }

    public decimal Bathrooms { get; set; }

    public decimal MonthlyRent { get; set; }

    public string? Description { get; set; }

    public bool IsAvailable { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Lease? Lease { get; set; }

    public virtual Owner Owner { get; set; } = null!;
}
