using DapperDemo.Application.Interfaces;
using DapperDemo.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DapperDemo.Infrastructure
{
	public static class ServiceRegistration
	{
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

