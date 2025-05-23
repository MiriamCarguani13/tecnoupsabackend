using Microsoft.EntityFrameworkCore;
using TecnoupsaBackend.Models;

namespace TecnoupsaBackend.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Admin", Email = "admin@upsa.edu", Password = "admin123", Role = "Admin" }
        );
        modelBuilder.Entity<Room>().HasData(
            new Room { Id = 1, Name = "Sala 101", Building = "Edificio A", Capacity = 10 },
            new Room { Id = 2, Name = "Sala 102", Building = "Edificio B", Capacity = 8 }
        );
    }
}