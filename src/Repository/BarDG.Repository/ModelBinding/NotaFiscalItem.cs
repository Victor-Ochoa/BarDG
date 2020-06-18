using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Repository.ModelBinding
{
    public class NotaFiscalItem : IEntityTypeConfiguration<Domain.Entity.NotaFiscalItem>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.NotaFiscalItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.Notifications);
            builder.Property(x => x.Valor).HasConversion<double>();
            builder.Property(x => x.Desconto).HasConversion<double>();
        }
    }
}
