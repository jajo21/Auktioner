using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auktioner.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>// DbContext = en bas-DbContext klass som kommer från EF-Core paketet
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        DbSet<Article> articles;

        public DbSet<Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }
    }
}