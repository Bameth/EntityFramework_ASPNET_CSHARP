using Microsoft.EntityFrameworkCore;
using web.entities;

namespace web.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Dept> Depts { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Detail> Details { get; set; }
    }
}
