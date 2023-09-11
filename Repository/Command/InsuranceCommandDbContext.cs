using tadbirInsuranceApi.Data;
using tadbirInsuranceApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace tadbirInsuranceApi.Data
{

    public class InsuranceCommandDbContext : InsuranceQueryDbContext
    {
        protected override QueryTrackingBehavior QueryTrackingBehavior_ { get; set; } = QueryTrackingBehavior.TrackAll;
        protected override bool LazyLoadingEnabled_ { get; set; } = false;
        public InsuranceCommandDbContext(DbContextOptions<InsuranceCommandDbContext> options)
            : base(options)
        {
        } 
        protected override void OnEntityCreating(ModelBuilder modelBuilder) {
            OnUserCreating(modelBuilder);
            OnRoleCreating(modelBuilder);
            OnUserRoleCreating(modelBuilder);
            OnInsurancePolicyCreating(modelBuilder);
            RestrinctDeleteBehavior(modelBuilder);
        } 
        private void OnUserCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(e => e.mobile).HasMaxLength(11).IsFixedLength();
            modelBuilder.Entity<User>().Property(e => e.national_code).HasMaxLength(10).IsFixedLength();
            ColumnUnique(modelBuilder.Entity<User>().HasIndex(e => e.username));
        }
        private void OnRoleCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasIndex(p => new { p.name }).IsUnique();
        }
        private void OnUserRoleCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasIndex(bc => new { bc.user_id, bc.role_id }).IsUnique();

        }
        private void OnInsurancePolicyCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsurancePolicyCoverage>().HasIndex(bc => new { bc.insurance_policy_id, bc.coverage_id }).IsUnique();

        }
        public virtual void RestrinctDeleteBehavior(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        private void ColumnUnique(IndexBuilder ib, string? filter = null)
        {//e.g. filter= "[IsPrimary] = 1" 
            if (string.IsNullOrWhiteSpace(filter))
                ib.IsUnique();
            else ib.IsUnique().HasFilter(filter);
        }

    }
}
