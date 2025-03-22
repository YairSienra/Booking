using Contract;
using Contract.Request;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public ReservasController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("Reservados")]
        public IActionResult GetAllReserved()
        {
            var reservedBookings = _bookingService.GettingServicesReserved();
            return Ok(reservedBookings);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var services = await _bookingService.GettingServices();
            return Ok(services);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PostBooking request)
        {
            try
            {
                bool result = await _bookingService.PutBooking(request);
                if (result)
                {
                    return Ok(new { success = true, message = "Reserva creada exitosamente." });
                }
                else
                {
                    return BadRequest(new { success = false, message = "No se pudo crear la reserva." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}
