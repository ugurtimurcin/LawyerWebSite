using LawyerWebSite.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Mapping
{
    public class WorkAreaMap : IEntityTypeConfiguration<WokrArea>
    {
        public void Configure(EntityTypeBuilder<WokrArea> builder)
        {
            builder.Property(x => x.Desciption).HasColumnType("nvarchar(max)");
        }
    }
}
