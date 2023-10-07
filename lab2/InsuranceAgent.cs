using System;
using System.Collections.Generic;

namespace lab2;

public partial class InsuranceAgent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public int AgentType { get; set; }

    public decimal Salary { get; set; }

    public int Contract { get; set; }

    public double TransactionPercent { get; set; }

    public virtual AgentType AgentTypeNavigation { get; set; } = null!;

    public virtual Contract ContractNavigation { get; set; } = null!;

    public virtual ICollection<InsuranceCase> InsuranceCases { get; set; } = new List<InsuranceCase>();

    public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();
}
