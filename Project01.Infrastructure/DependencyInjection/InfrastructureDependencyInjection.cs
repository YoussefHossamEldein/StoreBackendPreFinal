using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Interfaces;
using Store.Infrastructure.DbContexts;
using Store.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.DependencyInjection
{
    public static class InfrastructureDependencyInjection 
    {
        public static IServiceCollection AddInfrastrucutreServices(
            this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
