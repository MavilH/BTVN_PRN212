using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Employee
{
    public decimal EmpId { get; set; }

    public string? Name { get; set; }

    public decimal? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ContractEmployee? ContractEmployee { get; set; }

    public virtual ICollection<JoinProject> JoinProjects { get; set; } = new List<JoinProject>();

    public virtual PermanentEmployee? PermanentEmployee { get; set; }
}
