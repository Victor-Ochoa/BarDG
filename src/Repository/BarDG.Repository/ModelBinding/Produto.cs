using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Repository.ModelBinding
{
    public class Produto : IEntityTypeConfiguration<Domain.Entity.Produto>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Produto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.Notifications);

            builder.HasData(
                InitiateValue.Produto.Cerveja,
                InitiateValue.Produto.Conhaque,
                InitiateValue.Produto.Suco,
                InitiateValue.Produto.Água
            );
        }
    }
}
