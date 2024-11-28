using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using FilmTrackerDev2.ClassLayer;
using System.Reflection.Emit;

public class TrackerDbContext : DbContext
{
    // Визначення таблиць через DbSet
    public DbSet<UserTable> Users { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<ViewTable> Views { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<ActorFilm> ActorFilms { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<GenreFilm> GenreFilms { get; set; }

    public TrackerDbContext(DbContextOptions<TrackerDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Налаштування таблиць
        modelBuilder.Entity<UserTable>().ToTable("user_table");
        modelBuilder.Entity<Film>().ToTable("films");
        modelBuilder.Entity<ViewTable>().ToTable("view_table");
        modelBuilder.Entity<Actor>().ToTable("actors");
        modelBuilder.Entity<ActorFilm>().ToTable("actorfilms");
        modelBuilder.Entity<Genre>().ToTable("genres");
        modelBuilder.Entity<GenreFilm>().ToTable("genrefilm");

        // Додати первинний ключ для UserTable
        modelBuilder.Entity<UserTable>().HasKey(u => u.UserId);  // Замініть на правильне ім'я стовпця, якщо необхідно

        // Composite Keys
        modelBuilder.Entity<ViewTable>().HasKey(v => new { v.UserId, v.FilmId });
        modelBuilder.Entity<ActorFilm>().HasKey(af => new { af.ActorId, af.FilmId });
        modelBuilder.Entity<GenreFilm>().HasKey(gf => new { gf.GenreId, gf.FilmId });

        // Зв’язки між таблицями
        modelBuilder.Entity<ViewTable>()
            .HasOne<UserTable>()
            .WithMany()
            .HasForeignKey(v => v.UserId)
            .HasConstraintName("fk_view_user");

        modelBuilder.Entity<ViewTable>()
            .HasOne<Film>()
            .WithMany()
            .HasForeignKey(v => v.FilmId)
            .HasConstraintName("fk_view_film");

        modelBuilder.Entity<ActorFilm>()
            .HasOne<Actor>()
            .WithMany()
            .HasForeignKey(af => af.ActorId)
            .HasConstraintName("fk_actor_id");

        modelBuilder.Entity<Actor>()
            .HasOne<Actor>()
            .WithMany()
            .HasForeignKey(af => af.ActorId)
            .HasConstraintName("fk_actor_id");

        modelBuilder.Entity<ActorFilm>()
            .HasOne<Film>()
            .WithMany()
            .HasForeignKey(af => af.FilmId)
            .HasConstraintName("fk_film_id");

        modelBuilder.Entity<GenreFilm>()
            .HasOne<Genre>()
            .WithMany()
            .HasForeignKey(gf => gf.GenreId)
            .HasConstraintName("fk_genre_id");

        modelBuilder.Entity<GenreFilm>()
            .HasOne<Film>()
            .WithMany()
            .HasForeignKey(gf => gf.FilmId)
            .HasConstraintName("fk_film_id");
    }

    // Приклад методу для виконання запитів
    public List<Film> GetAllFilms()
    {
        return Films.ToList();
    }
}

