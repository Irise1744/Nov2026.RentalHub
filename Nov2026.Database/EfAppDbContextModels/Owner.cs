using System;
using System.Collections.Generic;

namespace Nov2026.Database.EfAppDbContextModels;

public partial class Owner
{
    public int OwnerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
}
