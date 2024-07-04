using System;
using System.Collections.Generic;
using LearnAPI.Repos.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnAPI.Repos;

public partial class LearnDataContext : DbContext
{
    public LearnDataContext()
    {
    }

    public LearnDataContext(DbContextOptions<LearnDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.Property(e => e.CreditLimit).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
