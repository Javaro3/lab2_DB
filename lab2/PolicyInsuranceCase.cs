using System;
using System.Collections.Generic;

namespace lab2;

public partial class PolicyInsuranceCase
{
    public int PolicyId { get; set; }

    public int InsuranceCaseId { get; set; }

    public virtual InsuranceCase InsuranceCase { get; set; } = null!;

    public virtual Policy Policy { get; set; } = null!;
}
