using System;
using System.Collections.Generic;

namespace lab2;

public partial class InsuranceType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();
}
