using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HW8Project.Models
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

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<AssignmentTag> AssignmentTags { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Tagname> Tagnames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=AssignmentString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.Courseid)
                    .HasConstraintName("ASSIGNMENTS_FK_COURSE");
            });

            modelBuilder.Entity<AssignmentTag>(entity =>
            {
                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.AssignmentTags)
                    .HasForeignKey(d => d.Assignmentid)
                    .HasConstraintName("TAG_FK_ASSIGNMENT");

                entity.HasOne(d => d.Tagname)
                    .WithMany(p => p.AssignmentTags)
                    .HasForeignKey(d => d.Tagnameid)
                    .HasConstraintName("TAG_FK_TAGNAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
