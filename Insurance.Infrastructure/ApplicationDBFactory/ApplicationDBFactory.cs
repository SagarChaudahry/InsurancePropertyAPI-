
using Insurance.Domain.Entity.DbModel;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure
{
    public class ApplicationDBFactory : DbContext
    {
        public ApplicationDBFactory(DbContextOptions<ApplicationDBFactory> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }

        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<ConstructionType> ConstructionTypes { get; set; }
        public DbSet<Property> Properties { get; set; }

        public DbSet<InsuredPerson> InsuredPersons { get; set; }

        public DbSet<RiskType> RiskTypes { get; set; }
        public DbSet<PolicyStatus> PolicyStatuses { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<PolicyOP> PolicyOP { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===========================
            // USERS
            // ===========================
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.UserId);

                entity.HasOne<Role>()
                      .WithMany()
                      .HasForeignKey(e => e.RoleId);
            });

            // ===========================
            // ROLES
            // ===========================
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(e => e.RoleId);
            });

            // ===========================
            // REFRESH TOKENS
            // ===========================
            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("RefreshTokens");
                entity.HasKey(e => e.Rfid);

                entity.Property(e => e.Token)
                      .HasColumnName("RefreshToken");

                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(e => e.UserId);
            });

            // ===========================
            // PROVINCES
            // ===========================
            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("Provinces");
                entity.HasKey(e => e.ProvinceId);
            });

            // ===========================
            // DISTRICTS
            // ===========================
            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("Districts");
                entity.HasKey(e => e.DistrictId);

                entity.HasOne<Province>()
                      .WithMany()
                      .HasForeignKey(e => e.ProvinceId);
            });

            // ===========================
            // MUNICIPALITIES
            // ===========================
            modelBuilder.Entity<Municipality>(entity =>
            {
                entity.ToTable("Municipalities");
                entity.HasKey(e => e.MunicipalityId);

                entity.HasOne<District>()
                      .WithMany()
                      .HasForeignKey(e => e.DistrictId);
            });

            // ===========================
            // PROPERTY TYPES
            // ===========================
            modelBuilder.Entity<PropertyType>(entity =>
            {
                entity.ToTable("PropertyTypes");
                entity.HasKey(e => e.PropertyTypeId);
            });

            // ===========================
            // CONSTRUCTION TYPES
            // ===========================
            modelBuilder.Entity<ConstructionType>(entity =>
            {
                entity.ToTable("ConstructionTypes");
                entity.HasKey(e => e.ConstructionTypeId);
            });

            // ===========================
            // PROPERTIES
            // ===========================
            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Properties");
                entity.HasKey(e => e.PropertyId);

                entity.HasOne<PropertyType>()
                      .WithMany()
                      .HasForeignKey(e => e.PropertyTypeId);

                entity.HasOne<ConstructionType>()
                      .WithMany()
                      .HasForeignKey(e => e.ConstructionTypeId);

                entity.HasOne<Province>()
                      .WithMany()
                      .HasForeignKey(e => e.ProvinceId);

                entity.HasOne<District>()
                      .WithMany()
                      .HasForeignKey(e => e.DistrictId);

                entity.HasOne<Municipality>()
                      .WithMany()
                      .HasForeignKey(e => e.MunicipalityId);
            });

            // ===========================
            // INSURED PERSONS
            // ===========================
            modelBuilder.Entity<InsuredPerson>(entity =>
            {
                entity.ToTable("InsuredPersons");
                entity.HasKey(e => e.InsuredId);
            });

            // ===========================
            // RISK TYPES
            // ===========================
            modelBuilder.Entity<RiskType>(entity =>
            {
                entity.ToTable("RiskTypes");
                entity.HasKey(e => e.RiskTypeId);
            });

            // ===========================
            // POLICY STATUS
            // ===========================
            modelBuilder.Entity<PolicyStatus>(entity =>
            {
                entity.ToTable("PolicyStatuses");
                entity.HasKey(e => e.PolicyStatusId);
            });

            // ===========================
            // POLICIES
            // ===========================
            modelBuilder.Entity<Policy>(entity =>
            {
                entity.ToTable("Policies");
                entity.HasKey(e => e.PolicyId);

                entity.HasOne<InsuredPerson>()
                      .WithMany()
                      .HasForeignKey(e => e.InsuredId);

                entity.HasOne<Property>()
                      .WithMany()
                      .HasForeignKey(e => e.PropertyId);

                entity.HasOne<RiskType>()
                      .WithMany()
                      .HasForeignKey(e => e.RiskTypeId);

                entity.HasOne<PolicyStatus>()
                      .WithMany()
                      .HasForeignKey(e => e.PolicyStatusId);
            });
            modelBuilder.Entity<PolicyOP>().HasNoKey().ToFunction("FGetPolicies");

        }
    }
}