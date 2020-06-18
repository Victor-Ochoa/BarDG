using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Repository.ModelBinding
{
    public class Promocao : IEntityTypeConfiguration<Domain.Entity.Promocao>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Promocao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.Notifications);
            builder.HasMany(x => x.ItensAtivadores);
            builder.HasOne(x => x.ItemDesconto);
            builder.Property(x => x.Desconto).HasConversion<double>();
        }
    }
}
