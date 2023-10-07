using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lab2;

public partial class InsuranceCompanyContext : DbContext
{
    public InsuranceCompanyContext()
    {
    }

    public InsuranceCompanyContext(DbContextOptions<InsuranceCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgentType> AgentTypes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientsView> ClientsViews { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<InsuranceAgent> InsuranceAgents { get; set; }

    public virtual DbSet<InsuranceAgentsView> InsuranceAgentsViews { get; set; }

    public virtual DbSet<InsuranceCase> InsuranceCases { get; set; }

    public virtual DbSet<InsuranceType> InsuranceTypes { get; set; }

    public virtual DbSet<Policy> Policies { get; set; }

    public virtual DbSet<PolicyInsuranceCase> PolicyInsuranceCases { get; set; }

    public virtual DbSet<PolicyView> PolicyViews { get; set; }

    public virtual DbSet<SupportingDocument> SupportingDocuments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=KOROL\\SQLEXPRESS;Initial Catalog=InsuranceCompany;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgentTyp__3214EC075CDF68EC");

            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clients__3214EC0743EDA985");

            entity.Property(e => e.Apartment).HasMaxLength(50);
            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.House).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(20);
            entity.Property(e => e.MobilePhone).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.PassportIdentification)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.PassportIssueDate).HasColumnType("date");
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(9)
                .IsFixedLength();
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(20);
        });

        modelBuilder.Entity<ClientsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ClientsView");

            entity.Property(e => e.Apartment).HasMaxLength(50);
            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.House).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(20);
            entity.Property(e => e.MobilePhone).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.PassportIdentification)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.PassportIssueDate).HasColumnType("date");
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(9)
                .IsFixedLength();
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(20);
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contract__3214EC071E24DAA3");

            entity.Property(e => e.EndDeadline).HasColumnType("date");
            entity.Property(e => e.Responsibilities).HasMaxLength(100);
            entity.Property(e => e.StartDeadline).HasColumnType("date");
        });

        modelBuilder.Entity<InsuranceAgent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Insuranc__3214EC071B7233A7");

            entity.Property(e => e.MiddleName).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.Surname).HasMaxLength(20);

            entity.HasOne(d => d.AgentTypeNavigation).WithMany(p => p.InsuranceAgents)
                .HasForeignKey(d => d.AgentType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InsuranceAgents_AgentTypes");

            entity.HasOne(d => d.ContractNavigation).WithMany(p => p.InsuranceAgents)
                .HasForeignKey(d => d.Contract)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InsuranceAgents_Contracts");
        });

        modelBuilder.Entity<InsuranceAgentsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("InsuranceAgentsView");

            entity.Property(e => e.EndDeadline).HasColumnType("date");
            entity.Property(e => e.MiddleName).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Responsibilities).HasMaxLength(100);
            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.StartDeadline).HasColumnType("date");
            entity.Property(e => e.Surname).HasMaxLength(20);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<InsuranceCase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Insuranc__3214EC07245436C3");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.InsurancePayment).HasColumnType("money");

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.InsuranceCases)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InsuranceCases_Clients");

            entity.HasOne(d => d.InsuranceAgentNavigation).WithMany(p => p.InsuranceCases)
                .HasForeignKey(d => d.InsuranceAgent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InsuranceCases_InsuranceAgents");

            entity.HasOne(d => d.SupportingDocumentNavigation).WithMany(p => p.InsuranceCases)
                .HasForeignKey(d => d.SupportingDocument)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InsuranceCases_SupportingDocuments");
        });

        modelBuilder.Entity<InsuranceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Insuranc__3214EC0795A5D734");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Policies__3214EC0721D8E412");

            entity.Property(e => e.ApplicationDate).HasColumnType("date");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.PolicyPayment).HasColumnType("money");

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Policies)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Policies_Clients");

            entity.HasOne(d => d.InsuranceAgentNavigation).WithMany(p => p.Policies)
                .HasForeignKey(d => d.InsuranceAgent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Policies_InsuranceAgents");

            entity.HasOne(d => d.InsuranceTypeNavigation).WithMany(p => p.Policies)
                .HasForeignKey(d => d.InsuranceType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Policies_InsuranceTypes");
        });

        modelBuilder.Entity<PolicyInsuranceCase>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.InsuranceCase).WithMany()
                .HasForeignKey(d => d.InsuranceCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyInsuranceCases_InsuranceCases");

            entity.HasOne(d => d.Policy).WithMany()
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyInsuranceCases_Policies");
        });

        modelBuilder.Entity<PolicyView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PolicyView");

            entity.Property(e => e.AgentMiddleName).HasMaxLength(20);
            entity.Property(e => e.AgentName).HasMaxLength(20);
            entity.Property(e => e.AgentSurname).HasMaxLength(20);
            entity.Property(e => e.Apartment).HasMaxLength(50);
            entity.Property(e => e.ApplicationDate).HasColumnType("date");
            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.ClientName).HasMaxLength(20);
            entity.Property(e => e.ClientSurname).HasMaxLength(20);
            entity.Property(e => e.ClintMiddleName).HasMaxLength(20);
            entity.Property(e => e.EndDeadline).HasColumnType("date");
            entity.Property(e => e.House).HasMaxLength(50);
            entity.Property(e => e.InsuranceTypeName).HasMaxLength(100);
            entity.Property(e => e.MobilePhone).HasMaxLength(20);
            entity.Property(e => e.PassportIdentification)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.PassportIssueDate).HasColumnType("date");
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(9)
                .IsFixedLength();
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.PolicyPayment).HasColumnType("money");
            entity.Property(e => e.Responsibilities).HasMaxLength(100);
            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.StartDeadline).HasColumnType("date");
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<SupportingDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supporti__3214EC07C5B6BCD5");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
