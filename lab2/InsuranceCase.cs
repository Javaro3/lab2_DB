using System;
using System.Collections.Generic;

namespace lab2;

public partial class InsuranceCase
{
    public int Id { get; set; }

    public int Client { get; set; }

    public int InsuranceAgent { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    public int SupportingDocument { get; set; }

    public decimal InsurancePayment { get; set; }

    public virtual Client ClientNavigation { get; set; } = null!;

    public virtual InsuranceAgent InsuranceAgentNavigation { get; set; } = null!;

    public virtual SupportingDocument SupportingDocumentNavigation { get; set; } = null!;
}
