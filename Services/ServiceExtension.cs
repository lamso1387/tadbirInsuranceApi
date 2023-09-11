using tadbirInsuranceApi.Data;
using tadbirInsuranceApi.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tadbirInsuranceApi.Services
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<InsuranceCommandDbContext>(options =>
            {
                options.UseNpgsql(AppConstants.Setting.db!.insurance_db_command_connection, builder =>
                {
                    BuildDatabse(builder);
                });

            });
            services.AddDbContextPool<InsuranceQueryDbContext>(options =>
            {
                options.UseNpgsql(AppConstants.Setting!.db!.insurance_db_query_connection, builder =>
                {
                    BuildDatabse(builder);
                });

            });
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<UnitOfService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            return services;
        }

        private static void BuildDatabse(NpgsqlDbContextOptionsBuilder builder)
        {
            builder.EnableRetryOnFailure(2, TimeSpan.FromSeconds(3), null);
            builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
        }
    }
}