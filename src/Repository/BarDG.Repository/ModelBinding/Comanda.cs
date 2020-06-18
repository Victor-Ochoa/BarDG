using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Repository.ModelBinding
{
    public class Comanda : IEntityTypeConfiguration<Domain.Entity.Comanda>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Comanda> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.Notifications);
            builder.HasMany(x => x.Itens);
        }
    }
}
