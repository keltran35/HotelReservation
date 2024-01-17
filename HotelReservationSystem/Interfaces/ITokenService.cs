using HotelReservationSystem.Entities;

namespace HotelReservationSystem.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}