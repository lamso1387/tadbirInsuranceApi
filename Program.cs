
using delivtadbirInsuranceApieryApi.Middleware;
using Microsoft.EntityFrameworkCore;
using tadbirInsuranceApi.Data;
using tadbirInsuranceApi.Middleware;
using tadbirInsuranceApi.Services;

namespace tadbirInsuranceApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDIServices(builder.Configuration);
            builder.Services.AddCors();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMvc()
              .AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.PropertyNamingPolicy = null;//avoid cameCase or Uppercase or any convert just defaul
                  options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());//convert enum to api in api responce
                  options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;//not result null item in api resporce
                  options.JsonSerializerOptions.WriteIndented = true;
              });

            var app = builder.Build();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()!.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<InsuranceCommandDbContext>();
                // context.Database.Migrate();
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<JwtMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}