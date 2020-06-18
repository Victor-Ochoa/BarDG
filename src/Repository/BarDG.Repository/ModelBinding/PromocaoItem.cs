using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Repository.ModelBinding
{
    public class PromocaoItem : IEntityTypeConfiguration<Domain.Entity.PromocaoItem>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.PromocaoItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.Notifications);
            builder.HasOne(x => x.Item);
        }
    }
}
