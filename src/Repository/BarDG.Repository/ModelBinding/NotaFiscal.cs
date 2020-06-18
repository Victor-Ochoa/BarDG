using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Repository.ModelBinding
{
    public class NotaFiscal : IEntityTypeConfiguration<Domain.Entity.NotaFiscal>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.NotaFiscal> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.Notifications);
        }
    }
}
