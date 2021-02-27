using LawyerWebSite.Entities.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LawyerWebSite.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(a => a.Name).IsRequired();

            builder.HasMany(a => a.Articles).WithOne(s => s.Category).HasForeignKey(a => a.CategoryId);

            builder.HasData(
                new Category { Id = 1, Name = "Ceza Hukuku", Url = "ceza-hukuku" },
                new Category { Id = 2, Name = "Tazminat Hukuku", Url = "tazminat-hukuku" },
                new Category { Id = 3, Name = "Medeni Hukuk", Url = "medeni-hukuk" }
                );
        }
    }
}
