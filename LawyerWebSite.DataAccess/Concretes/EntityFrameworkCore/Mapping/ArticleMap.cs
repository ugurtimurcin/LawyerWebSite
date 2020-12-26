using LawyerWebSite.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Mapping
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(a => a.Title).HasMaxLength(175).IsRequired();
            builder.Property(a => a.Content).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
