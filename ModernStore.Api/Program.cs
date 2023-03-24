using ModernStore.Domain.Repository;
using ModernStore.Infra.Context;
using ModernStore.Infra.Repository;
using System.Runtime.CompilerServices;

namespace ModernStore.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ConfigureServices(builder); 


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapControllers();
            app.Run();

            
        }

         private static void ConfigureServices(WebApplicationBuilder builder) {
            builder.Services.AddControllers();

            builder.Services.AddDbContext<ModernStoreDbContext>();
            builder.Services.AddTransient<IproductRepository, ProdutoRepository>(); 
            builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
            builder.Services.AddTransient<IOrderRepository, OrderRepository>(); 
        }
    }
}