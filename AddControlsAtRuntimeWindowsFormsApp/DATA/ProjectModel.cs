namespace AddControlsAtRuntimeWindowsFormsApp.DATA
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectModel : DbContext
    {
        public ProjectModel()
            : base("name=ProjectModel")
        {
        }

        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(e => e.ApprovedBudget)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Project>()
                .Property(e => e.ActualToDate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProjectedBudget)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProjectedCostVariance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Project>()
                .Property(e => e.WorkOrder_BaseEstimate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Project>()
                .Property(e => e.WorkOrder_BaseEstimateVariance)
                .HasPrecision(19, 4);
        }
    }
}
