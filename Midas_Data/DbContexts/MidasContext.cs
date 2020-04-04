using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Midas_Data.Entities;

namespace Midas_Data.Models
{
    public partial class MidasContext : IdentityDbContext<ApplicationUser>
    {
        public MidasContext()
        {
        }

        public MidasContext(DbContextOptions<MidasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BudgetBoard> BudgetBoard { get; set; }
        public virtual DbSet<BudgetBoardBills> BudgetBoardBills { get; set; }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<ExpenseType> ExpenseType { get; set; }
        public virtual DbSet<MonthlyBudgetBoard> MonthlyBudgetBoard { get; set; }
        public virtual DbSet<MonthlyBudgetExpense> MonthlyBudgetExpense { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("MidasDatabase");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BudgetBoard>(entity =>
            {
                entity.HasKey(e => e.BudgetBoardId);

                entity.Property(e => e.BudgetBoardName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BudgetBoardBills>(entity =>
            {
                entity.HasKey(e => e.BudgetBoardBillsId);
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasKey(e => e.ExpenseId);

                entity.Property(e => e.ExpenseName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExpenseType>(entity =>
            {
                entity.HasKey(e => e.ExpenseTypeId);

                entity.Property(e => e.ExpenseTypeName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MonthlyBudgetBoard>(entity =>
            {
                entity.HasKey(e => e.MonthlyBudgetId);

                entity.Property(e => e.MonthlyBudgetId).ValueGeneratedNever();

                entity.Property(e => e.MonthlyBudgetName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MonthlyBudgetExpense>(entity =>
            {
                entity.HasKey(e => e.MonthlyBudgetExpenseId);
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
