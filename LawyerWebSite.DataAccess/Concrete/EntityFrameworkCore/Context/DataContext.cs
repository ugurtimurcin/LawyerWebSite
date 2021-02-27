using LawyerWebSite.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using LawyerWebSite.Entities.Concrete.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LawyerWebSite.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\SQLEXPRESS; Database = LawArticleDb; Integrated Security = True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Turkish_CI_AS");

            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new WorkAreaMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<WorkArea> WokrAreas { get; set; }


    }
}
