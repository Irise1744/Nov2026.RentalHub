using System;
using System.Collections.Generic;

namespace Nov2026.Database.EfAppDbContextModels;

public partial class Lease
{
    public int LeaseId { get; set; }

    public int PropertyId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal MonthlyRent { get; set; }

    public decimal SecurityDeposit { get; set; }

    public byte PaymentDueDay { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<LeaseTenant> LeaseTenants { get; set; } = new List<LeaseTenant>();

    public virtual Property Property { get; set; } = null!;

    public virtual ICollection<RentPayment> RentPayments { get; set; } = new List<RentPayment>();
}
