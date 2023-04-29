
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;

namespace ProductCatalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            // Add services to the container.

            builder.Services.AddControllers();

            //Dependency injection happens from below code
            builder.Services.AddDbContext<CatalogContext>(
                options => options.UseSqlServer(configuration["ConnectionString"]),
                ServiceLifetime.Transient
                );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            //Asking for all scope of the service providers
            var scope = app.Services.CreateScope();
            var serviceproviders= scope.ServiceProvider;
            //The below line checks if there's a DB created & running in a virtual machine
            var context = serviceproviders.GetRequiredService<CatalogContext>();
            CatalogSeed.Seed(context);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}