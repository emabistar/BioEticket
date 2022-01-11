using bioticket.Models;
using Microsoft.EntityFrameworkCore;

namespace bioticket.Data
{
    public class AppDbContext :DbContext
    {

       

            // the translator
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Actor_Movie>().HasKey(a_m => new
                {
                    a_m.ActorId,
                    a_m.MovieId,
                });
                modelBuilder.Entity<Actor_Movie>().HasOne(a_m => a_m.Movie).WithMany(a_m => a_m.Actors_Movies).HasForeignKey(a_m => a_m.MovieId);
                modelBuilder.Entity<Actor_Movie>().HasOne(a_m => a_m.Actor).WithMany(a_m => a_m.Actors_Movies).HasForeignKey(a_m => a_m.ActorId);

                base.OnModelCreating(modelBuilder);
            }
            public DbSet<Actor> Actors { get; set; }
            public DbSet<Movie> Movies { get; set; }
            public DbSet<Actor_Movie> Actors_Movies { get; set; }
            public DbSet<Cinema> Cinemas { get; set; }
            public DbSet<Producer> Producers { get; set; }


        
    }
}
