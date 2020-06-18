using BarDG.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Infra
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection service)
        {
            service.AddTransient(typeof(Domain.Interface.IRepository<>), typeof(Repository.RepositoryBase<>));

            service.AddDbContext<ApiDbContext>(p => {
                p.EnableSensitiveDataLogging();
                p.UseLazyLoadingProxies();
                p.UseSqlite("DataSource=dbofile.db");
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
