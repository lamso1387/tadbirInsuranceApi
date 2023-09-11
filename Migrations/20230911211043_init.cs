using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tadbirInsuranceApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coverages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    min_capial = table.Column<long>(type: "bigint", nullable: false),
                    max_capial = table.Column<long>(type: "bigint", nullable: false),
                    rate = table.Column<double>(type: "double precision", nullable: false),
                    creator_id = table.Column<long>(type: "bigint", nullable: false),
                    modifier_id = table.Column<long>(type: "bigint", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coverages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePolicies",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    total_premium = table.Column<long>(type: "bigint", nullable: false),
                    creator_id = table.Column<long>(type: "bigint", nullable: false),
                    modifier_id = table.Column<long>(type: "bigint", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    permissions = table.Column<string>(type: "text", nullable: false),
                    creator_id = table.Column<long>(type: "bigint", nullable: false),
                    modifier_id = table.Column<long>(type: "bigint", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    national_code = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    mobile = table.Column<string>(type: "character(11)", fixedLength: true, maxLength: 11, nullable: false),
                    password_hash = table.Column<byte[]>(type: "bytea", nullable: false),
                    password_salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    change_pass_next_login = table.Column<bool>(type: "boolean", nullable: true),
                    last_login = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_admin = table.Column<bool>(type: "boolean", nullable: false),
                    creator_id = table.Column<long>(type: "bigint", nullable: false),
                    modifier_id = table.Column<long>(type: "bigint", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePolicyCoverages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    insurance_policy_id = table.Column<long>(type: "bigint", nullable: false),
                    coverage_id = table.Column<long>(type: "bigint", nullable: false),
                    capital = table.Column<long>(type: "bigint", nullable: false),
                    rate = table.Column<double>(type: "double precision", nullable: false),
                    coverage_premium = table.Column<long>(type: "bigint", nullable: false),
                    creator_id = table.Column<long>(type: "bigint", nullable: false),
                    modifier_id = table.Column<long>(type: "bigint", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicyCoverages", x => x.id);
                    table.ForeignKey(
                        name: "FK_InsurancePolicyCoverages_Coverages_coverage_id",
                        column: x => x.coverage_id,
                        principalTable: "Coverages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsurancePolicyCoverages_InsurancePolicies_insurance_policy~",
                        column: x => x.insurance_policy_id,
                        principalTable: "InsurancePolicies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false),
                    creator_id = table.Column<long>(type: "bigint", nullable: false),
                    modifier_id = table.Column<long>(type: "bigint", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicyCoverages_coverage_id",
                table: "InsurancePolicyCoverages",
                column: "coverage_id");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicyCoverages_insurance_policy_id_coverage_id",
                table: "InsurancePolicyCoverages",
                columns: new[] { "insurance_policy_id", "coverage_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_name",
                table: "Roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_role_id",
                table: "UserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_user_id_role_id",
                table: "UserRoles",
                columns: new[] { "user_id", "role_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_username",
                table: "Users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsurancePolicyCoverages");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Coverages");

            migrationBuilder.DropTable(
                name: "InsurancePolicies");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
