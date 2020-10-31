using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HW5Project.Models
{
    public partial class AssignmentsDbContext : DbContext
    {
        public AssignmentsDbContext()
        {
        }

        public AssignmentsDbContext(DbContextOptions<AssignmentsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignments> Assignments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=AssignmentString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
