using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Project
{
    public int ProjId { get; set; }

    public string? ProjName { get; set; }

    public virtual ICollection<JoinProject> JoinProjects { get; set; } = new List<JoinProject>();
}
