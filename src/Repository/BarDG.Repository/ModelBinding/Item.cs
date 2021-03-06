﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Repository.ModelBinding
{
    public class Item : IEntityTypeConfiguration<Domain.Entity.ComandaItem>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.ComandaItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.Notifications);
            builder.Property(x => x.Desconto).HasConversion<double>();
        }
    }
}
