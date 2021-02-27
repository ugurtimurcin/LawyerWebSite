using LawyerWebSite.Entities.Concretes;
using LawyerWebSite.Entities.Concretes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Mapping
{
    public class WorkAreaMap : IEntityTypeConfiguration<WorkArea>
    {
        public void Configure(EntityTypeBuilder<WorkArea> builder)
        {
            builder.Property(x => x.Desciption).HasColumnType("nvarchar(max)");

            builder.HasData(
                new WorkArea { Id = 1, CategoryId = 1, Desciption = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus.", Picture = "ceza-hukuku.jpg" },
                new WorkArea { Id = 2, CategoryId = 2, Desciption = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus.", Picture = "tazminat-hukuku.jpg" },
                new WorkArea { Id = 3, CategoryId = 3, Desciption = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus.", Picture = "medeni-hukuk.jpg" }
                );
        }
    }
}
