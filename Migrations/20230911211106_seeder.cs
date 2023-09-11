using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using tadbirInsuranceApi.Data;
using tadbirInsuranceApi.Domain;

#nullable disable

namespace tadbirInsuranceApi.Migrations
{
    /// <inheritdoc />
    public partial class seeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InsuranceCommandDbContext>();
            optionsBuilder.UseNpgsql(AppConstants.Setting.db.insurance_db_command_connection);
            InsuranceCommandDbContext db = new Data.InsuranceCommandDbContext(optionsBuilder.Options);
            User admin_user = new User
            {
                creator_id = 1,
                first_name = "admin",
                last_name = "admin",
                mobile = "09000000000",
                password = AppConstants.Setting.seeder.admin_seeder_password,
                username = AppConstants.Setting.seeder.admin_seeder_username,
                national_code = AppConstants.Setting.seeder.admin_seeder_national_code,
                is_admin = true,
                create_date = DateTime.UtcNow
            };
            admin_user.UpdatePasswordHash();
            db.Add(admin_user);
            db.SaveChanges();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
