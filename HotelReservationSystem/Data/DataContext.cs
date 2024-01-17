using HotelReservationSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<RoomTypes> RoomTypes { get; set; }
    public DbSet<AppUser> Users { get; set; }

  }
}