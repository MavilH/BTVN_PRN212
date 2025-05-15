using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class JoinProject
{
    public decimal EmpId { get; set; }

    public int ProjId { get; set; }

    public DateOnly? StartDate { get; set; }

    public virtual Employee Emp { get; set; } = null!;

    public virtual Project Proj { get; set; } = null!;
}
