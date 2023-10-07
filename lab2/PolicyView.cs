using System;
using System.Collections.Generic;

namespace lab2;

public partial class PolicyView
{
    public string AgentName { get; set; } = null!;

    public string AgentSurname { get; set; } = null!;

    public string AgentMiddleName { get; set; } = null!;

    public string Type { get; set; } = null!;

    public decimal Salary { get; set; }

    public string Responsibilities { get; set; } = null!;

    public DateTime StartDeadline { get; set; }

    public DateTime EndDeadline { get; set; }

    public double TransactionPercent { get; set; }

    public DateTime ApplicationDate { get; set; }

    public string PolicyNumber { get; set; } = null!;

    public string InsuranceTypeName { get; set; } = null!;

    public string ClientName { get; set; } = null!;

    public string ClientSurname { get; set; } = null!;

    public string ClintMiddleName { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public string MobilePhone { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string House { get; set; } = null!;

    public string Apartment { get; set; } = null!;

    public string PassportNumber { get; set; } = null!;

    public DateTime PassportIssueDate { get; set; }

    public string PassportIdentification { get; set; } = null!;

    public int PolicyTerm { get; set; }

    public decimal PolicyPayment { get; set; }
}
