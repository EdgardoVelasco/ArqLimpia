using Microsoft.AspNetCore.Mvc;
using RestfulReservas.Business.Services;
using RestfulReservas.Data.DTOs;
using RestfulReservas.Data.Repositories;

namespace RestfulReservas.Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly UserRepository _userRepository;

        public ReservationController(IReservationService reservationService,
            UserRepository userRepository)
        {
            _reservationService = reservationService;
            _userRepository = userRepository;
        }


        [HttpGet("users")]
        public IActionResult GetUser()
        {
            var users = _userRepository.FindAll();
            return Ok(users);
        }

        [HttpPost("reservation")]
        public IActionResult CreateReservation([FromBody] ReservationDTO dto)
        {
            try
            {
                Console.WriteLine($"input {dto}");
                int result = _reservationService.Create(dto);
                return result > 0 ? Ok("Reservacion creada") : BadRequest("algo sucedio");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("reservation")]
        public IActionResult GetReservations()
        {
            var reservations = _reservationService.GetAll();
            return Ok(reservations);
        }


        [HttpGet("rooms")]
        public IActionResult GetAvailableRooms()
        {
            var rooms = _reservationService.GetAvailableRooms();
            return Ok(rooms);

        }





    }
}
