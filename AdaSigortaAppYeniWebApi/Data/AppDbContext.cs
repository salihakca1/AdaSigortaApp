using AdaSigortaAppYeniWebApi.Models;
using Microsoft.EntityFrameworkCore;


namespace AdaSigortaAppYeniWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = default!;

        public DbSet<Person> Person { get; set; } = default!;
        public DbSet<Traffic> Trafik { get; set; } = default!;
        public DbSet<Dask> Dask { get; set; } = default!;

    }
}
