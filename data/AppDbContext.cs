using Microsoft.EntityFrameworkCore;
using web.entities;

namespace web.data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public required DbSet<Dept> Depts { get; set; }
        public required DbSet<Articles> Articles { get; set; }
        public required DbSet<Client> Clients { get; set; }
        public required DbSet<User> Users { get; set; }
        public required DbSet<Detail> Details { get; set; }
    }
}
