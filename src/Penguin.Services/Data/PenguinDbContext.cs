using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Penguin.Services.Data.Models;

namespace Penguin.Services.Data
{
    public class PenguinDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<CoverArt> CoverArt { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Song> Songs { get; set; }

        public string DbPath { get; }

        public PenguinDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            DbPath = Path.Join(path, "penguin.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}")
                .LogTo(s => Debug.WriteLine(s))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}