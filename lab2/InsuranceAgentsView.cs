using System;
using System.Collections.Generic;

namespace lab2;

public partial class InsuranceAgentsView
{
    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string Type { get; set; } = null!;

    public decimal Salary { get; set; }

    public string Responsibilities { get; set; } = null!;

    public DateTime StartDeadline { get; set; }

    public DateTime EndDeadline { get; set; }

    public double TransactionPercent { get; set; }
}
