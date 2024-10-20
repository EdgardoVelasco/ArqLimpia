using Microsoft.AspNetCore.Mvc;
using GestionTransacciones.Interfaces;
using GestionTransacciones.Models;

namespace GestionTransacciones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionController : ControllerBase
    {
        private readonly ITransaccionService _transaccionService;

        public TransaccionController(ITransaccionService transaccionService)
        {
            _transaccionService = transaccionService;
        }

        [HttpPost("deposito")]
        public IActionResult Depositar([FromBody] DepositoRequest request)
        {
            var transaccion = _transaccionService.RealizarDeposito(request.Monto);
            return Ok(transaccion);
        }

        [HttpPost("retiro")]
        public IActionResult Retirar([FromBody] RetiroRequest request)
        {
            var transaccion = _transaccionService.RealizarRetiro(request.Monto);  // Extrae el monto del JSON
            return Ok(transaccion);
        }

        [HttpGet("saldo")]
        public IActionResult ObtenerSaldo()
        {
            var saldo = _transaccionService.ObtenerSaldo();
            return Ok(saldo);
        }
    }
}