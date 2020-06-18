using BarDG.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Repository
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) :base(options)
        { }

        public DbSet<Domain.Entity.Produto> Produtos{ get; set; }
        public DbSet<Domain.Entity.Comanda> Comandas{ get; set; }
        public DbSet<Domain.Entity.NotaFiscal> NotaFiscais{ get; set; }
        public DbSet<Domain.Entity.NotaFiscalItem> NotaFiscalItens{ get; set; }
        public DbSet<Domain.Entity.ComandaItem> Itens{ get; set; }
        public DbSet<Domain.Entity.Promocao> Promocoes{ get; set; }
        public DbSet<Domain.Entity.PromocaoItem> PromocaoItens{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ModelBinding.Produto).Assembly);
        }
    }
}
