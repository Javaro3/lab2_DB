using System;
using System.Collections.Generic;

namespace lab2;

public partial class Policy
{
    public int Id { get; set; }

    public int InsuranceAgent { get; set; }

    public DateTime ApplicationDate { get; set; }

    public string PolicyNumber { get; set; } = null!;

    public int InsuranceType { get; set; }

    public int Client { get; set; }

    public int PolicyTerm { get; set; }

    public decimal PolicyPayment { get; set; }

    public virtual Client ClientNavigation { get; set; } = null!;

    public virtual InsuranceAgent InsuranceAgentNavigation { get; set; } = null!;

    public virtual InsuranceType InsuranceTypeNavigation { get; set; } = null!;
}
