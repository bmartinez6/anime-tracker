using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class AnimeDB : DbContext
    {
        public AnimeDB() : base() { }

        public AnimeDB(DbContextOptions options) : base(options) { }

        public DbSet<Anime> Animes { get; set; }
    }
}
