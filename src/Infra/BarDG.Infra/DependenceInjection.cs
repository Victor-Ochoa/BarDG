using BarDG.Repository;
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
                p.UseLazyLoadingProxies();
                p.UseSqlite("DataSource=dbofile.db");
            });

            return service;
        }
    }
}
