using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniWallet.Domain.Interfaces.Repositories;
using MiniWallet.Domain.SeedWork;
using MiniWallet.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MiniWalletDbContext>(options =>
            options.UseSqlServer(configuration?.GetConnectionString("SqlServer")));

            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

    }
}
