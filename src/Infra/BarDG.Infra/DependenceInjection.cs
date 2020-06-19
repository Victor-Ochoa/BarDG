using BarDG.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Identity;
using NetDevPack.Identity.Jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Infra
{
    public static class DependenceInjection
    {
        public static IServiceCollection addIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityEntityFrameworkContextConfiguration(options =>
                    options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("BarDG.Repository")
                )
            );

            services.AddJwtConfiguration(configuration, "AppSettings");

            services.AddIdentityConfiguration();

            return services;
        }
        public static IServiceCollection AddRepository(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient(typeof(Domain.Interface.IRepository<>), typeof(Repository.RepositoryBase<>));

            service.AddDbContext<ApiDbContext>(p =>
            {
                p.EnableSensitiveDataLogging();
                p.UseLazyLoadingProxies();
                p.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            return service;
        }
        public static IServiceCollection AddMediator(this IServiceCollection service)
        {
            var assemblyCommand = AppDomain.CurrentDomain.Load("BarDG.Domain");
            var assemblyHandler = AppDomain.CurrentDomain.Load("BarDG.Service");

            service.AddMediatR(assemblyCommand, assemblyHandler);

            return service;
        }
    }
}
