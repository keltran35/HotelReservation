using HotelReservationSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("{guests}")]
        public ActionResult<IEnumerable<string>> MakeReservation(int guests)
        {
            var result = _reservationService.MakeReservation(guests);
            return Ok(new {result});
        }
    }
}