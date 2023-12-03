using Microsoft.EntityFrameworkCore;

namespace TP3.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            string GenreJSon = System.IO.File.ReadAllText("C:\\Users\\Elyes Belgouthi\\source\\repos\\TP3\\TP3\\Models\\Genre.json");
            List<Genre>? genres = System.Text.Json.
            JsonSerializer.Deserialize<List<Genre>>(GenreJSon);
            foreach (Genre c in genres)
                modelBuilder.Entity<Genre>()
                .HasData(c);

            modelBuilder.Entity<Movie>().HasOne(m => m.Genre).WithMany(g => g.Movies).HasForeignKey(m => m.genre_id);
            modelBuilder.Entity<Movie>().HasMany(m => m.Customers).WithMany(c => c.Movies);
            modelBuilder.Entity<Customer>().HasOne(c => c.MembershipType).WithMany(m => m.Customers);
        }

    }
}
