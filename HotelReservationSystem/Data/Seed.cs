using System.Text.Json;
using HotelReservationSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Data
{
  public class Seed
  {
    public static async Task SeedRoomTypes(DataContext context)
    {
      if (await context.RoomTypes.AnyAsync()) return;

      var roomTypesData = await File.ReadAllTextAsync("Data/RoomTypesSeedData.json");

      var roomTypes = JsonSerializer.Deserialize<List<RoomTypes>>(roomTypesData);
      foreach (var roomType in roomTypes)
      {
        context.RoomTypes.Add(roomType);
      }

      await context.SaveChangesAsync();
    }
  }
}