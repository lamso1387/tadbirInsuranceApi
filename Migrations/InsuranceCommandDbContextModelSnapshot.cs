﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using tadbirInsuranceApi.Data;

#nullable disable

namespace tadbirInsuranceApi.Migrations
{
    [DbContext(typeof(InsuranceCommandDbContext))]
    partial class InsuranceCommandDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("tadbirInsuranceApi.Domain.Coverage", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTime>("create_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("creator_id")
                        .HasColumnType("bigint");

                    b.Property<long>("max_capial")
                        .HasColumnType("bigint");

                    b.Property<long>("min_capial")
                        .HasColumnType("bigint");

                    b.Property<long?>("modifier_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("modify_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("rate")
                        .HasColumnType("double precision");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Coverages");
                });

            modelBuilder.Entity("tadbirInsuranceApi.Domain.InsurancePolicy", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTime>("create_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("creator_id")
                        .HasColumnType("bigint");

                    b.Property<long?>("modifier_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("modify_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("total_premium")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("InsurancePolicies");
                });

            modelBuilder.Entity("tadbirInsuranceApi.Domain.InsurancePolicyCoverage", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<long>("capital")
                        .HasColumnType("bigint");

                    b.Property<long>("coverage_id")
                        .HasColumnType("bigint");

                    b.Property<long>("coverage_premium")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("create_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("creator_id")
                        .HasColumnType("bigint");

                    b.Property<long>("insurance_policy_id")
                        .HasColumnType("bigint");

                    b.Property<long?>("modifier_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("modify_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("rate")
                        .HasColumnType("double precision");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("coverage_id");

                    b.HasIndex("insurance_policy_id", "coverage_id")
                        .IsUnique();

                    b.ToTable("InsurancePolicyCoverages");
                });

            modelBuilder.Entity("tadbirInsuranceApi.Domain.Role", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTime>("create_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("creator_id")
                        .HasColumnType("bigint");

                    b.Property<long?>("modifier_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("modify_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("permissions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("tadbirInsuranceApi.Domain.User", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<bool?>("change_pass_next_login")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("create_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("creator_id")
                        .HasColumnType("bigint");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("is_admin")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("last_login")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("mobile")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character(11)")
                        .IsFixedLength();

                    b.Property<long?>("modifier_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("modify_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("national_code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character(10)")
                        .IsFixedLength();

                    b.Property<byte[]>("password_hash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("password_salt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("tadbirInsuranceApi.Domain.UserRole", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTime>("create_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("creator_id")
                        .HasColumnType("bigint");

                    b.Property<long?>("modifier_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("modify_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("role_id")
                        .HasColumnType("bigint");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("role_id");

                    b.HasIndex("user_id", "role_id")
                        .IsUnique();

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("tadbirInsuranceApi.Domain.InsurancePolicyCoverage", b =>
                {
                    b.HasOne("tadbirInsuranceApi.Domain.Coverage", "coverage")
                        .WithMany("insurance_policies")
                        .HasForeignKey("coverage_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("tadbirInsuranceApi.Domain.InsurancePolicy", "insurance_policy")
                        .WithMany("coverages")
                        .HasForeignKey("insurance_policy_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("coverage");

                    b.Navigation("insurance_policy");
                });

            modelBuilder.Entity("tadbirInsuranceApi.Domain.UserRole", b =>
                {
                    b.HasOne("tadbirInsuranceApi.Domain.Role", "role")
                        .WithMany("user_roles")
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("tadbirInsuranceApi.Domain.User", "user")
                        .WithMany("user_roles")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("role");

                    b.Navigation("user");
                });

            modelBuilder.Entity("tadbirInsuranceApi.Domain.Coverage", b =>
                {
                    b.Navigation("insurance_policies");
                });

            modelBuilder.Entity("tadbirInsuranceApi.Domain.InsurancePolicy", b =>
                {
                    b.Navigation("coverages");
                });

            modelBuilder.Entity("tadbirInsuranceApi.Domain.Role", b =>
                {
                    b.Navigation("user_roles");
                });

            modelBuilder.Entity("tadbirInsuranceApi.Domain.User", b =>
                {
                    b.Navigation("user_roles");
                });
#pragma warning restore 612, 618
        }
    }
}
