using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.CommandHendler;
using ModernStore.Domain.Repository;
using ModernStore.Domain.Services;
using ModernStore.Infra.Context;
using ModernStore.Infra.Repository;
using ModernStore.Infra.Services;
using ModernStore.Infra.UniteOfWork;
using ModernStore.Shared.UniteOfWork;

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

            builder.Services.AddDbContext<ModernStoreDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnections")));

            builder.Services.AddTransient<IproductRepository, ProdutoRepository>(); 
            builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
            builder.Services.AddTransient<IOrderRepository, OrderRepository>();
            builder.Services.AddTransient<IUniteOfWork, UniteOfWork>();
            builder.Services.AddTransient<ProductCommandHendler, ProductCommandHendler>(); 
            builder.Services.AddTransient<CustomerCommandHandler, CustomerCommandHandler>();
            builder.Services.AddTransient<IEmailService, EmailService>(); 
            
        }
    }
}