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
        public DbSet<Domain.Entity.NotaFiscal> NotaFiscals{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entity.Produto>().HasKey(x => x.Id);
            modelBuilder.Entity<Domain.Entity.Comanda>().HasKey(x => x.Id);
            modelBuilder.Entity<Domain.Entity.NotaFiscal>().HasKey(x => x.Id);

            modelBuilder.Entity<Domain.Entity.Produto>().HasData(
                new Domain.Entity.Produto
                {
                    Descricao = "Cerveja",
                    Valor = 5
                },
                new Domain.Entity.Produto
                {
                    Descricao = "Conhaque",
                    Valor = 20
                },
                new Domain.Entity.Produto
                {
                    Descricao = "Suco",
                    Valor = 50
                },
                new Domain.Entity.Produto
                {
                    Descricao = "Água",
                    Valor = 70
                }
            );
        }
    }
}
