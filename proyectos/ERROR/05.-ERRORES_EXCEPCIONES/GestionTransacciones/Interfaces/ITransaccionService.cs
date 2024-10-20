using GestionTransacciones.Models;

namespace GestionTransacciones.Interfaces
{
    public interface ITransaccionService
    {
        Transaccion RealizarDeposito(decimal monto);
        Transaccion RealizarRetiro(decimal monto);
        decimal ObtenerSaldo();
    }
}