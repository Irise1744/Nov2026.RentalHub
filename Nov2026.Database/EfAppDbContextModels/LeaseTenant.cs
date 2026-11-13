using System;
using System.Collections.Generic;

namespace Nov2026.Database.EfAppDbContextModels;

public partial class LeaseTenant
{
    public int LeaseId { get; set; }

    public int TenantId { get; set; }

    public bool IsPrimary { get; set; }

    public virtual Lease Lease { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;
}
