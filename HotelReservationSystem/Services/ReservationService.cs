using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystem.Data;
using HotelReservationSystem.Entities;
using HotelReservationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Services
{
    public class ReservationService : IReservationService
    {
        private readonly DataContext _context;

        public ReservationService(DataContext context)
        {
            _context = context;
        }

        public string MakeReservation(int guests)
        {
            var roomTypes = _context.RoomTypes.ToList();
            var options = FindBestOptions(guests, roomTypes);

            if (!options.Any() || options == null || options.All(sublist => sublist == null || !sublist.Any()))
                return "No option";

            var bestOption = options.OrderBy(option => option.Sum(roomType => roomType.Prices)).First();

            return FormatOutput(bestOption);
        }

        private List<List<RoomTypes>> FindBestOptions(int guests, List<RoomTypes> roomTypes)
        {
            var combinations = new List<List<RoomTypes>>();
            FindBestOptionsHelper(guests, roomTypes, 0, new List<RoomTypes>(), combinations);
            return combinations;
        }

        private void FindBestOptionsHelper(int guests, List<RoomTypes> roomTypes, int currentIndex, List<RoomTypes> currentCombination, List<List<RoomTypes>> combinations)
        {
            if (guests == 0)
            {
                combinations.Add(new List<RoomTypes>(currentCombination));
                return;
            }

            for (int i = currentIndex; i < roomTypes.Count; i++)
            {
                var roomType = roomTypes[i];

                if (roomType.Sleeps <= guests)
                {
                    for (int j = 1; j <= roomType.NumberOfRooms; j++)
                    {
                        currentCombination.Add(roomType);
                        FindBestOptionsHelper(guests - roomType.Sleeps, roomTypes, i + 1, currentCombination, combinations);
                    }

                    for (int j = 1; j <= roomType.NumberOfRooms; j++)
                    {
                        currentCombination.RemoveAt(currentCombination.Count - 1);
                    }
                }
            }
        }

        private string FormatOutput(List<RoomTypes> roomTypes)
        {
            var orderedRoomTypes = roomTypes.OrderByDescending(rt => rt.Prices).ToList();
            return string.Join(" ", orderedRoomTypes.Select(rt => rt.RoomType)) + $" - ${orderedRoomTypes.Sum(rt => rt.Prices)}";
        }
    }
}