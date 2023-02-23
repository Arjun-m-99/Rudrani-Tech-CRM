using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Rudrani_Tech_CRM.Models;

public partial class RudraniCrmContext : DbContext
{
    //public RudraniCrmContext()
    //{
    //}

    public RudraniCrmContext(DbContextOptions<RudraniCrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCreateLead> TblCreateLeads { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-6AIBT7VI;Database=rudrani_crm;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCreateLead>(entity =>
        {
            entity.HasKey(e => e.LeadId).HasName("PK_CreateLead");

            entity.ToTable("tblCreateLead");

            entity.HasIndex(e => e.Email, "UQ_CreateLead_Email").IsUnique();

            entity.HasIndex(e => e.Mobile, "UQ_CreateLead_Mobile").IsUnique();

            entity.Property(e => e.LeadId).HasColumnName("lead_id");
            entity.Property(e => e.AnnualRevenue).HasColumnName("annual_revenue");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Company)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("company");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creation_date");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmailOptOut)
                .HasDefaultValueSql("((0))")
                .HasColumnName("email_opt_out");
            entity.Property(e => e.Fax)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fax");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.FirstNameTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name_title");
            entity.Property(e => e.Industry)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("industry");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            //entity.Property(e => e.LeadImage).HasColumnName("lead_image");
            entity.Property(e => e.LeadOwner)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lead_owner");
            entity.Property(e => e.LeadSource)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lead_source");
            entity.Property(e => e.LeadStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lead_status");
            entity.Property(e => e.Mobile).HasColumnName("mobile");
            entity.Property(e => e.NoOfEmployees).HasColumnName("no_of_employees");
            entity.Property(e => e.Rating)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rating");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.SecondaryEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("secondary_email");
            entity.Property(e => e.SkypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("skype_id");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .IsUnicode(false)
                .HasColumnName("street");
            entity.Property(e => e.Tel).HasColumnName("tel");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Twitter)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("twitter");
            entity.Property(e => e.Website)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("website");
            entity.Property(e => e.Zipcode).HasColumnName("zipcode");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
