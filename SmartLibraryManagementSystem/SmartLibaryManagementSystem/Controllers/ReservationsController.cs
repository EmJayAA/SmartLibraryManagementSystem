using Microsoft.AspNetCore.Mvc;
using SmartLibrary.Core.DTOs.Reservations;
using SmartLibrary.Core.Interfaces;

namespace SmartLibaryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> Reserve(CreateReservationDto dto)
        {
            return Ok(await _reservationService.ReserveBookAsync(dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            var result = await _reservationService.CancelReservationAsync(id);
            return result ? Ok("Cancelled") : NotFound();
        }
    }
}
