using tadbirInsuranceApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace tadbirInsuranceApi.Data
{
    public class InsuranceQueryDbContext : DbContext
    {
        protected virtual QueryTrackingBehavior QueryTrackingBehavior_ { get; set; } = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
        protected virtual bool LazyLoadingEnabled_ { get; set; } = false;
        public InsuranceQueryDbContext(DbContextOptions<InsuranceQueryDbContext> options)
            : base(options)
        {
            Init();
        }
        protected InsuranceQueryDbContext(DbContextOptions options)
            : base(options)
        {
            Init();
        }
        public virtual void Init()
        {
            ChangeTracker.LazyLoadingEnabled = LazyLoadingEnabled_;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior_;
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnRelationCreating(modelBuilder);
            OnEntityCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        protected void OnRelationCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasOne(bc => bc.user).WithMany(b => b.user_roles).HasForeignKey(bc => bc.user_id);
            modelBuilder.Entity<UserRole>().HasOne(bc => bc.role).WithMany(c => c.user_roles).HasForeignKey(bc => bc.role_id);

            modelBuilder.Entity<InsurancePolicyCoverage>().HasOne(bc => bc.insurance_policy).WithMany(b => b.coverages).HasForeignKey(bc => bc.insurance_policy_id);
            modelBuilder.Entity<InsurancePolicyCoverage>().HasOne(bc => bc.coverage).WithMany(c => c.insurance_policies).HasForeignKey(bc => bc.coverage_id);
        }
        protected virtual void OnEntityCreating(ModelBuilder modelBuilder) { }

        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public DbSet<Coverage> Coverages { get; set; }
        public DbSet<InsurancePolicyCoverage> InsurancePolicyCoverages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
