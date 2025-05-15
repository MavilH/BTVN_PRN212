using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class ContractEmployee
{
    public decimal EmpId { get; set; }

    public decimal? DailyPay { get; set; }

    public int? NumberOfDays { get; set; }

    public virtual Employee Emp { get; set; } = null!;
}
