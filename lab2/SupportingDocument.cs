﻿using System;
using System.Collections.Generic;

namespace lab2;

public partial class SupportingDocument
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<InsuranceCase> InsuranceCases { get; set; } = new List<InsuranceCase>();
}
