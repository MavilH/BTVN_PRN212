using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class PermanentEmployee
{
    public decimal EmpId { get; set; }

    public decimal? BaseSalary { get; set; }

    public int? SalaryScale { get; set; }

    public virtual Employee Emp { get; set; } = null!;
}
